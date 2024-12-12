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
    private Rigidbody2D Srigidbody;

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

    private void Awake()
    {
        Srigidbody = GetComponent<Rigidbody2D>();
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
    if (player != null){

    }
    else
    {
        Debug.LogError("Player object not found!");
    }
}


    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if (player == null || pointA == null || pointB == null) return;

        // Detect player
        bool playerDetected = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerDetected && player.GetComponent<PlayerController>().hidden == false)
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
        if(isChasing == false)
        {
            chaseStart = transform.position;
        }
        isChasing = true;

    }

    public void StopChasing()
    {
        isChasing = false;
    }

    private void Patrol()
    {
        Vector2 patDirection = (currentTarget - transform.position).normalized;
        /*debug for why shark movement wasn't working
         * Debug.Log(patDirection);
        Debug.Log((Vector2)Srigidbody.position);
        Debug.Log((Vector2)Srigidbody.position + patDirection * patrolSpeed * Time.fixedDeltaTime);*/
        Srigidbody.MovePosition((Vector2)transform.position+patDirection*patrolSpeed*Time.fixedDeltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, currentTarget, patrolSpeed * Time.deltaTime);

        // Switch patrol target
        if (Vector2.Distance(transform.position, currentTarget) < 0.5f)
        {
            currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
            gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
        }
    }

    private void ChasePlayer()
    {
        /*if(((Mathf.Abs(transform.position.x) + Mathf.Abs(transform.position.y) - (Mathf.Abs(chaseStart.x)+Mathf.Abs(chaseStart.y))) > 10) || player.GetComponent<PlayerController>().hidden == true){
            Debug.Log("stopped chasing");
            StopChasing();
        }*/
        if (player != null)
        {
            Vector2 targetDirection = (player.transform.position - transform.position).normalized;
            Debug.Log(targetDirection);
            Srigidbody.MovePosition((Vector2)transform.position+(Vector2)targetDirection*chaseSpeed* Time.fixedDeltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
