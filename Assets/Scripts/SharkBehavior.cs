using UnityEngine;

public class SharkBehavior : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2f;

    [Header("Chase Settings")]
    public float chaseSpeed = 4f;
    private Transform player;

    [Header("Detection Settings")]
    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    private bool isChasing = false;
    private Vector3 currentTarget;

    // For SFX
    private SFXManager sfxManager;
    private bool isIntenseMusicPlaying = false;

    void Start()
    {
        // Set initial patrol target
        currentTarget = pointB.position;

        // Find player reference
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Find SFXManager
        sfxManager = FindObjectOfType<SFXManager>();
    }

    void Update()
    {
        // Check if the player is within detection radius
        bool playerDetected = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerDetected)
        {
            StartChasing();

            // Switch to intense shark music if not already playing
            if (!isIntenseMusicPlaying)
            {
                sfxManager.SwitchToSharkMusic(true);
                isIntenseMusicPlaying = true;
            }
        }
        else
        {
            StopChasing();

            // Revert to normal music if the player is no longer detected
            if (isIntenseMusicPlaying)
            {
                sfxManager.SwitchToSharkMusic(false);
                isIntenseMusicPlaying = false;
            }
        }

        // Perform the appropriate behavior
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        // Move toward the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, patrolSpeed * Time.deltaTime);

        // Switch target if close to the current target point
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void ChasePlayer()
    {
        // Move toward the player's position
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    public void StartChasing()
    {
        isChasing = true;
    }

    public void StopChasing()
    {
        isChasing = false;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize detection radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}