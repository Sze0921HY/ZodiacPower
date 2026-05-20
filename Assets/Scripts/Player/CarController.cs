using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float acceleration = 50f;
    public float maxSpeed = 20f;
    public float turnSpeed = 100f;
    public float friction = 0.98f;
    public float downForce = 1f;
    public float jumpForce = 300f;

    [Header("Input Actions")]
    public InputActionAsset inputActions;
    private InputAction moveAction;
    private InputAction jumpAction;

    [Header("Rotation Recovery")]
    public float uprightSpeed = 2f;


    [Header("Wheel References")]
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;

    [Header("Wheel Settings")]
    public float wheelRadius = 0.5f;
    public float maxSteerAngle = 30f;

    [Header("Growth Settings")]
    public float pointThreshold = 100f;
    public float growthMultiplier = 0.2f;

    private float growPoint = 0f;
    private Vector3 originalScale;

    [Header("References")]
    public PointManager pointManager;
    public LevelManager levelManager;
    public CarStats carStats;

    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector3 jumpInput;
    private bool isGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        moveAction = inputActions.FindAction("Move");
        jumpAction = inputActions.FindAction("Jump");

        originalScale = transform.localScale;


    }

    void OnEnable()
    {
        moveAction.Enable();
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;

        jumpAction.Enable();
        jumpAction.performed += OnJumpPerformed;
    }

    void OnDisable()
    {
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;
        moveAction.Disable();

        jumpAction.performed -= OnJumpPerformed;
        jumpAction.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (isGround) 
        {
            isGround = false;
            rb.AddForce(Vector3.up * jumpForce * carStats.jump, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Check if car is upright (prevent flying when flipped)
        float upAngle = Vector3.Angle(transform.up, Vector3.up);
        // if the angle between the car and world up is less than 60 degrees, we consider it upright enough to move
        bool isUpright = upAngle < 60f;

        // can only move when upright
        if (moveInput.y != 0 && isUpright)
        {
            Vector3 forwardForce = transform.forward * moveInput.y * acceleration;
            rb.AddForce(forwardForce, ForceMode.Acceleration);
        }

        // Apply downforce to keep car grounded on floor if in air or moving too fast
        if (rb.linearVelocity.magnitude > 1f)
        {
            rb.AddForce(-transform.up * downForce, ForceMode.Acceleration);
        }


        if (rb.linearVelocity.magnitude > 0.5f && isUpright)
        {
            float turn = moveInput.x * turnSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // so that it doesn't automatically stop it slowly stops when not accelerating
        rb.linearVelocity *= friction;
        rb.angularVelocity *= friction;

        // Clamp speed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        // Slowly straighten the car only when grounded
        if (isGround)
        {
            Quaternion targetRotation = Quaternion.Euler(
                0,
                transform.eulerAngles.y,
                0
            );

            rb.MoveRotation(
                Quaternion.Slerp(
                    rb.rotation,
                    targetRotation,
                    uprightSpeed * Time.fixedDeltaTime
                )
            );
        }



        // Update wheel rotations
        UpdateWheels();
    }
    void UpdateWheels()
    {
       
        // if wheel go forward rotate forward, if wheel go backward rotate backward
        float speed = rb.linearVelocity.magnitude;
        float speedDirection = Vector3.Dot(rb.linearVelocity, transform.forward);
        float wheelRotation = (speed * Time.fixedDeltaTime) / wheelRadius * Mathf.Rad2Deg;

        // Apply rotation to all wheels around their X axis so they rotate as the car moves forward or backward
        if (frontLeftWheel != null)
        {
            frontLeftWheel.Rotate(wheelRotation * Mathf.Sign(speedDirection), 0, 0);
        }
        if (frontRightWheel != null)
        {
            frontRightWheel.Rotate(wheelRotation * Mathf.Sign(speedDirection), 0, 0);
        }
        if (rearLeftWheel != null)
        {
            rearLeftWheel.Rotate(wheelRotation * Mathf.Sign(-speedDirection), 0, 0);
        }
        if (rearRightWheel != null)
        {
            rearRightWheel.Rotate(wheelRotation * Mathf.Sign(speedDirection), 0, 0);
        }

        // Calculate steering angle for front wheels
        float steerAngle = moveInput.x * maxSteerAngle;

        // Rotate front wheels for steering
        if (frontLeftWheel != null)
        {
            frontLeftWheel.localRotation = Quaternion.Euler(0, steerAngle, 0);
        }
        if (frontRightWheel != null)
        {
            frontRightWheel.localRotation = Quaternion.Euler(0, steerAngle, 0);
        }

       
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemyObject = collision.gameObject;
            Object tempObject = enemyObject.GetComponent<Object>();
            Rigidbody tempEnemyRb = enemyObject.GetComponent<Rigidbody>();


            int tierIndex = (int)tempObject.TierObject;

            if (levelManager.TierBool[tierIndex])
            {
                if (!tempObject.isTouched)
                {
                    tempObject.isTouched = true;
                    Debug.Log("Touched Tier:" + tierIndex);

                    tempEnemyRb.isKinematic = false;


                    if (tierIndex == 1 || tierIndex == 2 || tierIndex == 0)
                    {
                        Vector3 direction = (enemyObject.transform.position - transform.position).normalized;
                        direction += Vector3.up;
                        tempEnemyRb.AddForce(direction * carStats.force, ForceMode.Impulse);
                    }
                    else
                    {
                        Vector3 direction = (enemyObject.transform.position - transform.position).normalized;
                        direction += Vector3.up;
                        tempEnemyRb.AddForce(direction, ForceMode.Impulse);
                    }


                    pointManager.addPoint(tempObject);
                    Grow(tempObject.Point);
                }
            }
            else
            {
                Debug.Log("Player not enough tier to booo this");
            }

        }
        else if (collision.gameObject.CompareTag("Egg"))
        {
            pointManager.ExtraPoint_Egg();
            Grow(pointManager.Extra_Egg);
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
    }




    public void Grow(float pointsEarned)
    {
        growPoint += pointsEarned;

        // Check if growPoint exceeds the threshold and grow the car accordingly if points pass the threshold carry over into the next growth
        while (growPoint >= pointThreshold)
        {
            growPoint -= pointThreshold;

            //local scale increase by growth multiplier, so it grows by a percentage of its current size rather than a fixed amount
            transform.localScale += Vector3.one * growthMultiplier;
            // Increase next threshold
            pointThreshold += 850f;

            Debug.Log("Player Grew!");
            Debug.Log("Next Growth Threshold: " + pointThreshold);
        }
    }

}