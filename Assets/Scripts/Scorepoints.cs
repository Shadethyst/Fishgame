using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Scorepoints : MonoBehaviour
{
    [Header("Score Settings")]
    public int pearlCount = 0; // Initial pearl count
    public Text pearlText; // UI Text to display the pearl count

    [Header("Events")]
    public UnityEvent Scored; // Event triggered when a score milestone is reached

    [Header("Audio")]
    private SFXManager sfxManager; // Reference to the SFXManager

    void Start()
    {
        // Find and assign the SFXManager
        sfxManager = FindObjectOfType<SFXManager>();
        
        // Initialize the pearl count text
        UpdatePearlText();
    }

    void Update()
    {
        // Continuously update the pearl count text
        UpdatePearlText();
    }

    public void PearlAdded()
    {
        pearlCount++;
        UpdatePearlText();

        // Trigger Scored event every 10 pearls
        if (pearlCount % 10 == 0)
        {
            Scored.Invoke();
        }
    }

    private void UpdatePearlText()
    {
        if (pearlText != null)
        {
            pearlText.text = pearlCount.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play sound effect using SFXManager
            if (sfxManager != null)
            {
                sfxManager.PlayPearlSound();
            }

            // Increment the pearl count and invoke events
            PearlAdded();

            // Destroy the pearl after collection
            Destroy(gameObject);
        }
    }
}