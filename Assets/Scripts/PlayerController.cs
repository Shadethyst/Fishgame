using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D pRigidbody;
    private PlayerInputs _playerInput;


    private float curDir;
    private Transform turnDir;
    InputAction moveR;
    InputAction moveU;
    InputAction moveL;
    InputAction moveD;

    private Vector3 rotateR;
    private float buttonAmount;


    //rotation stats
    private float rotSpeed;
    private Vector3 turnRot;
    private Quaternion _lookRotation;

    //Movement stats
    private float acceleration;
    private float maxSpeed;
    private float speed;
    private float deceleration;
    private float minSpeed;
    private float playerMod;
    private float actSpeed;
    private float minSpeedP;

    private bool inControl;


    private void Awake()
    {
        _playerInput = new PlayerInputs();
        pRigidbody = GetComponent<Rigidbody2D>();
        //_pTransform = GetComponent<Transform>();

        // fetches inputs from the project wide inputsystem asset
        moveR = InputSystem.actions.FindAction("TurnR");
        moveU = InputSystem.actions.FindAction("MoveUp");
        moveD = InputSystem.actions.FindAction("MoveDown");
        moveL = InputSystem.actions.FindAction("TurnL");
        if (pRigidbody == null)
        {
            Debug.Log("rigidbody2D is null");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        acceleration = 2f;
        speed = 1f;
        deceleration = 1f;
        minSpeed = 1.2f;
        maxSpeed = 10f;
        playerMod = 2f;
        actSpeed = 0;
        turnRot = new Vector3(0, 0, 0);
        minSpeedP = -4f;
        rotSpeed = 45f;

    }

    // Update is called once per frame
    void Update()
    {


        if (transform.eulerAngles.z > 90f || transform.eulerAngles.z < -90f)
        {

        }
        turnChar();
    }
    // FixedUpdate is called 50 times a second on a fixed interval
    private void FixedUpdate()
    {
        tankMove();
        moveChar();
    }

    /* 
     Moves character forward on Z axis based on actSpeed
     */
    private void moveChar()
    {
        pRigidbody.MovePosition((Vector2)transform.position + (Vector2)transform.right * actSpeed * Time.fixedDeltaTime);
    }
    private void turnChar()
    {
        transform.Rotate(turnRot * Time.deltaTime, Space.World);
        //_pTransform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.fixedDeltaTime * rotSpeed);
    }

    /*Movement done with wasd/arrow keys where: 
        w/up = increase movement speed
        s/down = reduce movement speed
        a/left = turn left
        d/right = turn right
     */
    private void tankMove() {
        if (moveR.IsPressed() && !moveL.IsPressed())
        {
            turnRot.Set(0, 0, -rotSpeed);
            //_lookRotation = Quaternion.LookRotation(turnRot);

        }
        else if (moveL.IsPressed() && !moveR.IsPressed())
        {
            turnRot.Set(0, 0, rotSpeed);
           // _lookRotation = Quaternion.LookRotation(turnRot);
        }
        else
        {
            turnRot.Set(0, 0, 0);
        }
        if (moveU.IsPressed())
        {
            if (speed < maxSpeed)
            {
                speed = speed + (acceleration * Time.fixedDeltaTime);
            }
            else if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (!moveU.IsPressed() && moveD.IsPressed())
        {
            if (speed < minSpeedP)
            {
                speed = -4f;
            }
            else
            {
                speed = speed - (deceleration * playerMod * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (speed < minSpeed && speed > -0.3f)
            {
                speed = 0f;
            }
            else if(speed < minSpeed)
            {
                speed += deceleration * Time.fixedDeltaTime;
            }
            else
            {
                speed = speed - (deceleration*Time.fixedDeltaTime);
            }
        }
        actSpeed = speed;
    }
    private void contextMove()
    {
        if (moveR.IsPressed() && !moveL.IsPressed())
        {
            buttonAmount++;
            turnRot.Set(0, 0, 0);

        }
        else if (moveL.IsPressed() && !moveR.IsPressed())
        {
            buttonAmount++;
            turnRot.Set(0, 0, 180f);
        }
        if (moveU.IsPressed() && !moveD.IsPressed())
        {
            buttonAmount++;
            turnRot.Set(0, 0, ((turnRot.z) + 90f) / buttonAmount);
        }
        else if (!moveU.IsPressed() && moveD.IsPressed())
        {
            buttonAmount++;
            turnRot.Set(0, 0, ((turnRot.z) - 90f) / buttonAmount);
        }
        buttonAmount = 0;
        if (speed > 0 && (!moveD.IsPressed() && !moveL.IsPressed() && !moveR.IsPressed() && !moveU.IsPressed()))
        {
            speed = speed - deceleration;
        }
        else if (speed < maxSpeed)
        {
            speed = speed * acceleration;
        }
    }
}



