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

    [Header("Input Actions")]
    public InputActionAsset inputActions;
    private InputAction moveAction;

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
        // Apply forward/backward force
        if (moveInput.y != 0)
        {
            Vector3 forwardForce = transform.forward * moveInput.y * acceleration;
            rb.AddForce(forwardForce, ForceMode.Acceleration);
        }


        if (rb.linearVelocity.magnitude > 0.5f)
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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Object tempObject = collision.gameObject.GetComponent<Object>();

            switch (tempObject.TierObject)
            {
                case ObjectEnum.Tier1:
                    Debug.Log("Touching Tier 1 object");
                    break;
                case ObjectEnum.Tier2:

                    break;
                case ObjectEnum.Tier3:

                    break;
                case ObjectEnum.Tier4:

                    break;
                case ObjectEnum.Tier5:

                    break;
                case ObjectEnum.Tier6:

                    break;
            }
        }
        else
        {

        }
    }


}