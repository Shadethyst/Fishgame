using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public MotionStats motionStats;

    private Rigidbody2D pRigidbody;
    private PlayerInputs _playerInput;
    private SpriteRenderer _spriteRenderer;

    InputAction moveR;
    InputAction moveU;
    InputAction moveL;
    InputAction moveD;
    InputAction dashButton;

    // Movement state
    public float speed;
    public float targetSpeed;
    public float dashTimer;
    public float dashCooldownTimer;
    public bool hidden;

    private bool inControl;

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Awake()
    {
        _playerInput = new PlayerInputs();
        pRigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Fetch inputs from the Input System asset
        moveR = _playerInput.Player_Map.TurnR;      // Action: Turn Right
        moveU = _playerInput.Player_Map.MoveUp;     // Action: Move Up
        moveD = _playerInput.Player_Map.MoveDown;   // Action: Move Down
        moveL = _playerInput.Player_Map.TurnL;      // Action: Turn Left
        dashButton = _playerInput.Player_Map.DashButton; // Action: Dash Button

        if (pRigidbody == null)
        {
            Debug.LogError("Rigidbody2D is not assigned or missing!");
        }
    }

    void Start()
    {
        speed = 0;
    }

    void Update()
    {
        // Check if the player is hiding
        if (hidden)
        {
            Debug.Log("Player is hiding. No movement allowed.");
            return;
        }
    }

    private void FixedUpdate()
    {
        if (hidden) return;

        float rot = transform.eulerAngles.z;
        _spriteRenderer.flipY = rot > 90 && rot < 270;

        Move(Time.fixedDeltaTime);
        Turn(Time.fixedDeltaTime);
    }

    private void Move(float deltaT)
    {
        var ms = motionStats;
        float acc = 0;

        if (dashButton.IsPressed() && dashCooldownTimer <= 0) // Start dash
        {
            targetSpeed = ms.dashSpeed;
            dashTimer = ms.dashTime;
            dashCooldownTimer = ms.dashCooldown;
        }
        else if (IsDashing())
        {
            dashTimer -= deltaT;
            acc = 3 * ms.acceleration;
            if (dashTimer < 0)
            {
                targetSpeed = 0;
                dashTimer = 0;
            }
        }
        else if (moveU.IsPressed()) // Move forward
        {
            targetSpeed = ms.maxSpeed;
            acc = ms.acceleration;
        }
        else if (moveD.IsPressed()) // Move backward
        {
            targetSpeed = ms.minSpeed;
            acc = ms.acceleration;
        }
        else // No dash or buttons, decelerate to zero
        {
            targetSpeed = 0;
            acc = ms.deceleration;
        }

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer = Mathf.Max(0, dashCooldownTimer - deltaT);
        }

        float deltaV = targetSpeed - speed;
        if (deltaV > 0)
        {
            speed = Mathf.Min(speed + acc * deltaT, targetSpeed);
        }
        else if (deltaV < 0)
        {
            speed = Mathf.Max(speed - acc * deltaT, targetSpeed);
        }

        Vector2 movement = speed * deltaT * (Vector2)transform.right;
        pRigidbody.MovePosition((Vector2)transform.position + movement);
    }

    private void Turn(float deltaT)
    {
        float heading = 0;
        float rotation = motionStats.turnSpeed * deltaT;

        if (moveR.IsPressed())
        {
            heading -= rotation;
        }
        else if (moveL.IsPressed())
        {
            heading += rotation;
        }

        transform.Rotate(heading * Vector3.forward, Space.World);
    }

    private bool IsDashing()
    {
        return dashTimer > 0;
    }

    public void TakeDamage(float damage)
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        else
        {
            Debug.LogError("PlayerHealth component is missing!");
        }
    }
}
