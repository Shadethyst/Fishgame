using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private Rigidbody2D bRigidbody;
    private float speed;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public float distance;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Vector3 disvec = new Vector3(distance, distance, 0);
        endPosition = transform.position + disvec;
        speed = 1;

        bRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bRigidbody.transform.position.x > endPosition.x || bRigidbody.transform.position.y > endPosition.y) {
            bRigidbody.transform.position = startPosition;
        }
    }
    void FixedUpdate()
    {
        move(Time.fixedDeltaTime, direction);
    }
    private void move(float deltaT, float dir)
    {
        switch (dir)
        {
            case 0:
                bRigidbody.MovePosition((Vector2)transform.position + speed * deltaT * (Vector2)transform.right);
                break;
            case 1:
                bRigidbody.MovePosition((Vector2)transform.position + speed * deltaT * (Vector2)transform.right * (-1));
                break;
            case 2:
                bRigidbody.MovePosition((Vector2)transform.position + speed * deltaT * (Vector2)transform.up);
                break;
            default:
                bRigidbody.MovePosition((Vector2)transform.position + speed * deltaT * (Vector2)transform.up * (-1));
                break;
        }
        
        

    }
}
