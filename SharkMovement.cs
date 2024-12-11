using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public float horizontalDistance = 5f; // Maximum distance for horizontal oscillation
    public float verticalDistance = 2f;   // Maximum distance for vertical oscillation
    public float moveSpeed = 1f;          // Speed of the oscillation
    public Transform playerFish;          // Reference to the player fish transform
    public float detectionRadius = 10f;  // Distance to start playing the shark song
    public AudioSource sharkSong;         // Audio source for the shark song

    private Vector3 startPos;             // To store the starting position of the shark
    private bool isPlayingSharkSong = false; // To track if the shark song is already playing

    private void Start()
    {
        // Save the initial position of the shark
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the new position with a sinusoidal pattern for both horizontal and vertical movement
        transform.position = new Vector3(
            startPos.x + Mathf.Sin(Time.time * moveSpeed) * horizontalDistance, // Horizontal oscillation
            startPos.y + Mathf.Cos(Time.time * moveSpeed) * verticalDistance,   // Vertical oscillation
            startPos.z
        );

        // Check if the shark is close enough to the player fish
        if (playerFish != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerFish.position);
            if (distanceToPlayer <= detectionRadius && !isPlayingSharkSong)
            {
                PlaySharkSong();
            }
            else if (distanceToPlayer > detectionRadius && isPlayingSharkSong)
            {
                StopSharkSong();
            }
        }
    }

    private void PlaySharkSong()
    {
        if (sharkSong != null)
        {
            sharkSong.Play();
            isPlayingSharkSong = true;
            Debug.Log("Shark song started playing!");
        }
    }

    private void StopSharkSong()
    {
        if (sharkSong != null)
        {
            sharkSong.Stop();
            isPlayingSharkSong = false;
            Debug.Log("Shark song stopped.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a gizmo to visualize the detection radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
