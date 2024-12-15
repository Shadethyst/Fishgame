using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public MotionStats motionStats;

    private Rigidbody2D pRigidbody;
    private PlayerInputs _playerInput;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private SFXManager sfxManager;
    [SerializeField] private AudioSource diveSoundSource;

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
    public bool hidden;

    private bool inControl;

    private Vector3 defaultScale;

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
        defaultScale = transform.localScale;
        SetInControl(true);
        SetVisibility(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is called 50 times a second on a fixed interval
    private void FixedUpdate()
    {
        if (inControl)
        {
            float rot = transform.eulerAngles.z;
            /*
            foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
            {

            }*/
            _spriteRenderer.flipY = rot > 90 && rot < 270;
            Move(Time.fixedDeltaTime);
            Turn(Time.fixedDeltaTime);
        }
    }

    private void Move(float deltaT)
    {
        var ms = motionStats;
        float acc = 0;
        if (DashButton.IsPressed() && dashCooldownTimer <= 0) // Start dash
        {
            sfxManager.PlaySound(diveSoundSource);
            targetSpeed = ms.dashSpeed;
            dashTimer = ms.dashTime;
            dashCooldownTimer = ms.dashCooldown;
            transform.localScale = new(defaultScale.x * 1.3f, defaultScale.y * 0.8f, 1);
        }
        else if (IsDashing())
        {
            dashTimer -= deltaT;
            acc = 3 * ms.acceleration;
            if (dashTimer < 0)
            {
                // Stop dash
                targetSpeed = 0;
                dashTimer = 0;
                transform.localScale = defaultScale;
            }
        }
        else if (moveU.IsPressed()) // Normal forward
        {
            targetSpeed = ms.maxSpeed;
            acc = ms.acceleration;
        }
        else if (!moveU.IsPressed() && moveD.IsPressed()) // Normal backward
        {
            targetSpeed = ms.minSpeed;
            acc = ms.acceleration;
        }
        else // No dash or buttons, decelerate to zero
        {
            targetSpeed = 0;
            acc = ms.deceleration;
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
    public void hiding()
    {
        hidden = true;
    }
    public void leavehiding()
    {
        hidden = false;
    }
    private bool IsDashing() { return dashTimer > 0; }

    public void SetInControl(bool value)
    {
        inControl = value;
    }

    public void SetVisibility(bool value)
    {
        _spriteRenderer.enabled = value;
    }

    public void takeDamage()
    {

    }
}



