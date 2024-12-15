using System;
using UnityEngine;

public class JellyfishMovement : MonoBehaviour
{
    public float moveDistance = 2f; // The maximum distance the jellyfish moves up and down
    public float moveSpeed = 1f;    // The speed of the jellyfish's oscillation

    private Vector3 startPos;       // To store the starting position of the jellyfish
    private float jitter;           // Randomize movement a bit

    private void Start()
    {
        jitter = UnityEngine.Random.value - 0.5f;
        // Save the initial position of the jellyfish
        startPos = transform.position;
    }

    private void Update()
    {
        var rigidBody = gameObject.GetComponent<Rigidbody2D>();

        // Calculate the new position with a sinusoidal pattern
        // pos(t) = a * sin(ft + p)
        // vel(t) = af * cos(ft + p)

        var phase = 2 * (float)Math.PI * jitter;
        var frequency = moveSpeed;
        var amplitude = (moveDistance + jitter);
        rigidBody.velocity = new Vector2(
            0,
            Mathf.Sin(Time.time * frequency + phase) * frequency * amplitude
        );
    }
}

/*
 
 * 
 * 
 * 
 */ 
