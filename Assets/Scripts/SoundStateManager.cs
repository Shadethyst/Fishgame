using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStateManager : MonoBehaviour
{

    public State CurrentSoundState;

    public void SetCurrentSoundState(State soundState)
    {
        CurrentSoundState = soundState;
    }

    public State GetCurrentSoundState()
    {
        return CurrentSoundState;
    }
}
