using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HidingPlace : MonoBehaviour
{
    private PlayerController player;
    
    void Start()
    {
        player = GameObject.FindAnyObjectByType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.hidden = true;
            Debug.Log("Player is hiding!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.hidden = false;
            Debug.Log("Player is no longer hiding!");
        }
    }
}
