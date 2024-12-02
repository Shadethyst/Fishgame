using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SOUND DETECTOR: USED BY THE PLAYER OBJECT TO DETECT LAYERS AND CHANGE SOUND STATES ACCORDINGLY
public class SoundDetector : MonoBehaviour
{
    [Header("Detection Layers")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask sharkLayer;

    [Header("Detection Settings")]
    [SerializeField] private float detectionRange = 5f;

    [Header("Sound State Management")]
    public SoundState soundstate;
    public SoundStateManager soundstateManager;

    private SharkBehavior sharkBehavior; // Reference to the SharkBehavior script

    void Start()
    {
        // Initialize sound state
        soundstate = soundstateManager.GetCurrentSoundState();

        // Find the shark in the scene and get its SharkBehavior script
        GameObject shark = GameObject.FindWithTag("Shark");
        if (shark != null)
        {
            sharkBehavior = shark.GetComponent<SharkBehavior>();
            if (sharkBehavior == null)
            {
                Debug.LogWarning("SharkBehavior script not found on Shark GameObject!");
            }
        }
        else
        {
            Debug.LogWarning("No GameObject with tag 'Shark' found in the scene!");
        }
    }

    void Update()
    {
        // Update the current sound state in the manager
        soundstateManager.SetCurrentSoundState(soundstate);
    }

    void FixedUpdate()
    {
        if (CheckSurroundings(sharkLayer))
        {
            soundstate = SoundState.Shark;
            TriggerSharkChase(); // Trigger chase logic
        }
        else if (CheckSurroundings(enemyLayer))
        {
            soundstate = SoundState.Enemy;
        }
        else
        {
            soundstate = SoundState.Idle;
            ResetSharkBehavior(); // Reset shark to patrol
        }

        Debug.Log($"Current Sound State: {soundstate}");
    }

    bool CheckSurroundings(LayerMask layer)
    {
        // Check if an object in the specified layer is within the detection range
        return Physics2D.OverlapCircle(transform.position, detectionRange, layer);
    }

    public SoundState GetSoundState()
    {
        return soundstate;
    }

    // Trigger the shark's chase behavior
    private void TriggerSharkChase()
    {
        if (sharkBehavior != null)
        {
            sharkBehavior.StartChasing();
            Debug.Log("Shark is now chasing the player!");
        }
    }

    // Reset the shark's behavior to patrol
    private void ResetSharkBehavior()
    {
        if (sharkBehavior != null)
        {
            sharkBehavior.StopChasing();
            Debug.Log("Shark has stopped chasing and resumed patrolling.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a gizmo to visualize the detection range in the editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}