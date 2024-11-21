using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource pearlSoundSource;
    [SerializeField] private AudioSource damageSoundSource;
    [SerializeField] private AudioSource bubbleSoundSource;
    [SerializeField] private AudioSource splashJumpSoundSource;
    [SerializeField] private AudioSource splashDiveJumpSource;

    public void PlaySound(AudioSource source)
    {
       Debug.Log("playing");
       source.clip = source.clip;
       source.Play();
    }
}
