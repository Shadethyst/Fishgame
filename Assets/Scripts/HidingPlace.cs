using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HidingPlace : MonoBehaviour
{
    private PlayerController player;
    public UnityEvent hiding;
    public UnityEvent leaveHiding;
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.hidden = true;
            hiding.Invoke();
            Debug.Log("Player is hiding!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leaveHiding.Invoke();
            player.hidden = false;
            Debug.Log("Player is no longer hiding!");
        }
    }
}
