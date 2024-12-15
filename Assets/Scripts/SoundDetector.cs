using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SOUND DETECTOR: USED BY THE PLAYER OBJECT TO DETECT LAYERS AND CHANGE SOUND STATES ACCORDINGLY
public class SoundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask sharkLayer;

    public SoundState soundstate;
    public SoundStateManager soundstateManager;

    [SerializeField] private float detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        soundstate = soundstateManager.GetCurrentSoundState();
    }

    // Update is called once per frame
    void Update()
    {
        soundstateManager.SetCurrentSoundState(soundstate);
    }
    
    void FixedUpdate()
    {
        if (CheckSurroundings(sharkLayer))
        {
            soundstate = SoundState.Shark;
        }
        else if (CheckSurroundings(enemyLayer))
        {
            soundstate = SoundState.Enemy;
        }
        else
        {
            soundstate = SoundState.Idle;
        }
    }

    bool CheckSurroundings(LayerMask layerName)
    {
        return Physics2D.OverlapCircle(transform.position, detectionRange, layerName);
    }

    public SoundState GetSoundState()
    {
        return soundstate;
    }
}
