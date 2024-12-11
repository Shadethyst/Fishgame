using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStateReset : MonoBehaviour
{

    private SoundStateManager soundStateManager;

    // Start is called before the first frame update
    void Awake()
    {
        soundStateManager = FindObjectOfType<SoundStateManager>();
        soundStateManager.SetCurrentSoundState(SoundState.Idle);
    }

}
