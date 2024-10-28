using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Range(1f, 100f)]
    public float acceleration = 40f;
    [Range(1f, 100f)]
    public float deceleration = 20f;
    [Range(0f, 100f)]
    public float maxSpeed = 20f;
    [Range(-100f, 0f)]
    public float minSpeed = -10f;
    [Range(0f, 1000f)]
    public float rotSpeed = 200f;
    [Range(0f, 200f)]
    public float dashSpeed = 60f;
    [Range(0f, 10f)]
    public float dashTime = 1f;
    [Range(0f, 100f)]
    public float dashCooldown = 5f;

    private Rigidbody2D pRigidbody;
    private PlayerInputs _playerInput;
    private SpriteRenderer _spriteRenderer;

    InputAction moveR;
    InputAction moveU;
    InputAction moveL;
    InputAction moveD;
    InputAction DashButton;

    // Movement state
    public float speed;
    public float targetSpeed;
    public float dashTimer;
    public float dashCooldownTimer;

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
    }

    private void Awake()
    {
        _playerInput = new PlayerInputs();
        pRigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // fetches inputs from the project wide inputsystem asset
        moveR = InputSystem.actions.FindAction("TurnR");
        moveU = InputSystem.actions.FindAction("MoveUp");
        moveD = InputSystem.actions.FindAction("MoveDown");
        moveL = InputSystem.actions.FindAction("TurnL");
        DashButton = InputSystem.actions.FindAction("DashButton");
        if (pRigidbody == null)
        {
            Debug.Log("rigidbody2D is null");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is called 50 times a second on a fixed interval
    private void FixedUpdate()
    {
        _spriteRenderer.flipY = Mathf.Abs(transform.eulerAngles.z) > 90f;

        Move(Time.fixedDeltaTime);
        Turn(Time.fixedDeltaTime);
    }

    private void Move(float deltaT)
    {
        float acc = 0;
        if (DashButton.IsPressed() && dashCooldownTimer <= 0) // Start dash
        {
            targetSpeed = dashSpeed;
            dashTimer = dashTime;
            dashCooldownTimer = dashCooldown;
        }
        else if (IsDashing())
        {
            dashTimer -= deltaT;
            acc = 3 * acceleration;
            if (dashTimer < 0)
            {
                // Stop dash
                targetSpeed = 0;
                dashTimer = 0;
            }
        }
        else if (moveU.IsPressed()) // Normal forward
        {
            targetSpeed = maxSpeed;
            acc = acceleration;
        }
        else if (!moveU.IsPressed() && moveD.IsPressed()) // Normal backward
        {
            targetSpeed = minSpeed;
            acc = acceleration;
        }
        else // No dash or buttons, decelerate to zero
        {
            targetSpeed = 0;
            acc = deceleration;
        }

        // Dash cooldown in progress
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

        pRigidbody.MovePosition((Vector2)transform.position + speed * deltaT * (Vector2)transform.right);
    }

    private void Turn(float deltaT)
    {
        float heading = 0;
        if (moveR.IsPressed())
        {
            heading -= rotSpeed * deltaT;
        }
        else if (moveL.IsPressed())
        {
            heading += rotSpeed * deltaT;
        }
        transform.Rotate(heading * Vector3.forward, Space.World);
    }

    private bool IsDashing() { return dashTimer > 0; }


    public void takeDamage()
    {

    }
}



