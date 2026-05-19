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

    [Header("Input Actions")]
    public InputActionAsset inputActions;
    private InputAction moveAction;


    [Header("Wheel References")]
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;

    [Header("Wheel Settings")]
    public float wheelRadius = 0.5f;
    public float maxSteerAngle = 30f;

    [Header("References")]
    public PointManager pointMangaer;
    public LevelManager levelManager;

    private Rigidbody rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        moveAction = inputActions.FindAction("Move");
    }

    void OnEnable()
    {
        moveAction.Enable();
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;
    }

    void OnDisable()
    {
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;
        moveAction.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    void FixedUpdate()
    {
        // Check if car is upright (prevent flying when flipped)
        float upAngle = Vector3.Angle(transform.up, Vector3.up);
        bool isUpright = upAngle < 60f;

        // Apply forward/backward force only when upright
        if (moveInput.y != 0 && isUpright)
        {
            Vector3 forwardForce = transform.forward * moveInput.y * acceleration;
            rb.AddForce(forwardForce, ForceMode.Acceleration);
        }

        // Apply downforce to keep car grounded
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

        // Update wheel rotations
        UpdateWheels();
    }
    void UpdateWheels()
    {
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

        // Calculate wheel rotation based on speed (forward/backward)
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
            rearLeftWheel.Rotate(wheelRotation * Mathf.Sign(speedDirection), 0, 0);
        }
        if (rearRightWheel != null)
        {
            rearRightWheel.Rotate(wheelRotation * Mathf.Sign(speedDirection), 0, 0);
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Object tempObject = collision.gameObject.GetComponent<Object>();

            int tierIndex = (int)tempObject.TierObject;

            if (levelManager.TierBool[tierIndex])
            {
                Debug.Log("Touched Tier:" + tierIndex);
                pointMangaer.addPoint(tempObject);
            }
            else
            {
                Debug.Log("Player not enough tier to booo this");
            }

        }
        else if (collision.gameObject.CompareTag("Egg"))
        {
            pointMangaer.ExtraPoint_Egg();
        }
    }


}