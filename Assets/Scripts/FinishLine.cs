using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private SoundStateManager soundStateManager;

    private void Awake()
    {
        soundStateManager = FindObjectOfType<SoundStateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Reached finish line!");
            soundStateManager.SetCurrentSoundState(SoundState.Win);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
