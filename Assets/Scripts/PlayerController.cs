using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D pRigidbody;
    private Transform _pTransform;
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


    private bool inControl;


    private void Awake()
    {
        _playerInput = new PlayerInputs();
        pRigidbody = GetComponent<Rigidbody2D>();
        _pTransform = GetComponent<Transform>();
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


    }

    // Update is called once per frame
    void Update()
    {
        tankMove();

        if (transform.eulerAngles.z > 90f || transform.eulerAngles.z < -90f)
        {
            transform.eulerAngles = new Vector3(0, 180f, transform.rotation.eulerAngles.z);
        }
        turnChar();
    }
    // FixedUpdate is called 50 times a second on a fixed interval
    private void FixedUpdate()
    {
        moveChar();
    }
    private void moveChar()
    {
        pRigidbody.MovePosition((Vector2)transform.position + (Vector2)transform.right * actSpeed * Time.fixedDeltaTime);
    }
    private void turnChar()
    {
        transform.Rotate(turnRot * Time.deltaTime);
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
            turnRot.Set(0, 0, -30f);
            //_lookRotation = Quaternion.LookRotation(turnRot);

        }
        else if (moveL.IsPressed() && !moveR.IsPressed())
        {
            turnRot.Set(0, 0, 30f);
           // _lookRotation = Quaternion.LookRotation(turnRot);
        }
        if (moveU.IsPressed())
        {
            if (speed < maxSpeed)
            {
                speed = speed * acceleration;
            }
            else if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (!moveU.IsPressed() && moveD.IsPressed())
        {
            if (speed < minSpeed)
            {
                speed = 1f;
            }
            else
            {
                speed = speed * deceleration * playerMod;
            }
        }
        else
        {
            if (speed < minSpeed)
            {
                speed = 1f;
            }
            else
            {
                speed = speed * deceleration;
            }
        }
        actSpeed = speed - 1f;
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



