using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D pRigidbody;
    private PlayerInputs _playerInput;
    private float acceleration;
    private float maxSpeed;
    private float speed;
    private float curDir;
    private Transform turnDir;
    InputAction moveR;
    InputAction moveU;
    InputAction moveL;
    InputAction moveD;
    private float rotSpeed;
    private Vector3 turnRot;
    private Vector3 rotateR;
    private float buttonAmount;
    private bool moving;
    private float deceleration;
    private float minSpeed;
    private float playerMod;


    private void Awake()
    {
        _playerInput = new PlayerInputs();
        pRigidbody = GetComponent<Rigidbody2D>();
        if(pRigidbody == null)
        {
            Debug.Log("rigidbody2D is null");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        rotateR = new Vector3(0, 0, 0);
        moveR = InputSystem.actions.FindAction("Right");
        moveU = InputSystem.actions.FindAction("Up");
        moveD = InputSystem.actions.FindAction("Down");
        moveL = InputSystem.actions.FindAction("Left");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // FixedUpdate is called 50 times a second on a fixed interval
    private void FixedUpdate()
    {


            

    }
    private void moveChar()
    {
        pRigidbody.MovePosition((Vector2)transform.position + (Vector2)transform.right * speed*Time.fixedDeltaTime);
    }
    private void tankMove() {
        if (moveR.IsPressed() && !moveL.IsPressed())
        {
            turnRot.Set(0, 0, -90f);

        }
        else if (moveL.IsPressed() && !moveR.IsPressed())
        {
            turnRot.Set(0, 0, 90f);
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
                speed = 0;
            }
            speed = speed * deceleration * playerMod;
        }
        else
        {
            if (speed < minSpeed)
            {
                speed = 0;
            }
            speed = speed * deceleration;
        }
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



