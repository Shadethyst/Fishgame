using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("Background Music")]
    [SerializeField] private AudioSource normalBackgroundMusic;
    [SerializeField] private AudioSource sharkBackgroundMusic;

    [Header("Audio Sources for SFX")]
    [SerializeField] private AudioSource generalAudioSource;
    [SerializeField] private AudioSource pearlSoundSource;
    [SerializeField] private AudioSource damageSoundSource;
    [SerializeField] private AudioSource bubbleSoundSource;
    [SerializeField] private AudioSource splashJumpSoundSource;
    [SerializeField] private AudioSource splashDiveSoundSource;

    [Header("Audio Clips for SFX")]
    [SerializeField] private AudioClip bubbleSFXv1;
    [SerializeField] private AudioClip bubbleSFXv2;
    [SerializeField] private AudioClip damageSFXv1;
    [SerializeField] private AudioClip damageSFXv2;
    [SerializeField] private AudioClip pearlSFX;
    [SerializeField] private AudioClip splashPart1;
    [SerializeField] private AudioClip splashPart2;

    /// <summary>
    /// Switches between normal background music and intense shark music.
    /// </summary>
    /// <param name="isSharkMusic">Set to true to play shark music, false for normal music.</param>
    public void SwitchToSharkMusic(bool isSharkMusic)
    {
        if (isSharkMusic)
        {
            if (sharkBackgroundMusic != null && !sharkBackgroundMusic.isPlaying)
            {
                normalBackgroundMusic.Stop();
                sharkBackgroundMusic.Play();
                Debug.Log("Switched to Shark music.");
            }
        }
        else
        {
            if (normalBackgroundMusic != null && !normalBackgroundMusic.isPlaying)
            {
                sharkBackgroundMusic.Stop();
                normalBackgroundMusic.Play();
                Debug.Log("Switched to Normal music.");
            }
        }
    }

    public void PlaySound(AudioSource source)
    {
        if (source != null && source.clip != null)
        {
            source.Play();
            Debug.Log($"Playing sound: {source.clip.name}");
        }
        else
        {
            Debug.LogWarning("AudioSource or its AudioClip is null! Check the SFXManager setup.");
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && generalAudioSource != null)
        {
            generalAudioSource.PlayOneShot(clip);
            Debug.Log($"Playing one-shot sound: {clip.name}");
        }
        else
        {
            Debug.LogWarning("AudioClip or General AudioSource is null! Check the SFXManager setup.");
        }
    }

    // Add specific sound play methods as needed
    // Specific sound trigger methods
    public void PlayBubbleSound(bool useVersion2 = false)
    {
        bubbleSoundSource.clip = useVersion2 ? bubbleSFXv2 : bubbleSFXv1;
        PlaySound(bubbleSoundSource);
    }

    public void PlayDamageSound(bool useVersion2 = false)
    {
        damageSoundSource.clip = useVersion2 ? damageSFXv2 : damageSFXv1;
        PlaySound(damageSoundSource);
    }

    public void PlayPearlSound()
    {
        pearlSoundSource.clip = pearlSFX;
        PlaySound(pearlSoundSource);
    }

    public void PlayJumpSound()
    {
        splashJumpSoundSource.clip = splashPart1;
        PlaySound(splashJumpSoundSource);
    }

    public void PlayDiveSound()
    {
        splashDiveSoundSource.clip = splashPart2;
        PlaySound(splashDiveSoundSource);
    }
}