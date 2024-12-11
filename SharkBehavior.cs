using UnityEngine;

public class SharkBehavior : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2f;

    [Header("Chase Settings")]
    public float chaseSpeed = 4f;
    public GameObject player;

    [Header("Detection Settings")]
    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    private bool isChasing = false;
    private Vector3 chaseStart;
    private Vector3 currentTarget;

    private SFXManager sfxManager;
void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1); // Reduce health by 1
            Debug.Log("Player damaged by shark!");
        }
    }
}

    private void Start()
{
    if (pointA == null || pointB == null)
    {
        Debug.LogError("Patrol points are not assigned!");
        enabled = false; // Disable the script
        return;
    }

    currentTarget = pointB.position;

    // Find player
    player = GameObject.FindGameObjectWithTag("Player");
    if (playerObject != null){

    }
    else
    {
        Debug.LogError("Player object not found!");
    }
}


    private void Update()
    {
        if (player == null || pointA == null || pointB == null) return;

        // Detect player
        bool playerDetected = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerDetected && !player.isHidden())
        {
            StartChasing();
        }
        else
        {
            StopChasing();
        }

        // Perform actions
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    public void StartChasing()
    {
        isChasing = true;
        chaseStart = transform.position;
    }

    public void StopChasing()
    {
        isChasing = false;
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, patrolSpeed * Time.deltaTime);

        // Switch patrol target
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void ChasePlayer()
    {
        if(((Mathf.abs(transform.position.x) + Mathf.abs(transform.position.y) - (Mathf.abs(chaseStart.x)+Mathf.abs(chaseStart.y))) > 10))){
            StopChasing();
        }
        else if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
