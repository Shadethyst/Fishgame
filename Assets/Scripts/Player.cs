using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player;
    private float acceleration;
    private float maxSpeed;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // FixedUpdate is called 50 times a second on a fixed interval
    private void FixedUpdate()
    {
        if (speed < maxSpeed) {
            speed = acceleration * Time.fixedDeltaTime;
                }
    }
}
