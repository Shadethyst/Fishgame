using UnityEngine;

public class JellyfishMovement : MonoBehaviour
{
    public float moveDistance = 2f; // The maximum distance the jellyfish moves up and down
    public float moveSpeed = 1f;    // The speed of the jellyfish's oscillation

    private Vector3 startPos;       // To store the starting position of the jellyfish

    private void Start()
    {
        // Save the initial position of the jellyfish
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the new position with a sinusoidal pattern
        transform.position = new Vector3(
            startPos.x,
            startPos.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance,
            startPos.z
        );
    }
}
