using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    public State soundstate;
    public SoundStateManager soundstatemanager;
    [SerializeField] private float detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        soundstate = soundstatemanager.GetCurrentSoundState();
    }

    // Update is called once per frame
    void Update()
    {
        soundstatemanager.SetCurrentSoundState(soundstate);
    }
    
    void FixedUpdate()
    {
        if (CheckForEnemies())
        {
            soundstate = State.Enemy;
        }

        if (!CheckForEnemies())
        {
            soundstate = State.Idle;
        }
    }

    bool CheckForEnemies()
    {
        return Physics.CheckSphere(transform.position, detectionRange, enemyLayer);
    }

    public State GetSoundState()
    {
        return soundstate;
    }
}
