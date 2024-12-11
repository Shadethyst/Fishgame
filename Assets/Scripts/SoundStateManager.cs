using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SOUND STATE MANAGER: 
public class SoundStateManager : MonoBehaviour
{

    public SoundState CurrentSoundState;

    public void SetCurrentSoundState(SoundState soundState)
    {
        CurrentSoundState = soundState;
    }

    public SoundState GetCurrentSoundState()
    {
        return CurrentSoundState;
    }
}
