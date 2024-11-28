using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeController : MonoBehaviour
{

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer sfxMixer;

    [SerializeField] private AudioSource soundTestSource;

    private float musicVolumeValue;
    private float sfxVolumeValue;


    private void Start()
    {
        PrepareMusicVolume();
        PrepareSFXVolume();
    }

    private void Update()
    {
        Debug.Log(musicSlider.value);
        Debug.Log(sfxSlider.value);
    }

    public void ResetAllVolumes()
    {
        musicSlider.value = 1.0f;
        sfxSlider.value = 1.0f;

        musicVolumeValue = musicSlider.value;
        sfxVolumeValue = sfxSlider.value;

        musicMixer.SetFloat("Music", Mathf.Log(musicVolumeValue) * 20);
        sfxMixer.SetFloat("SFX", Mathf.Log(sfxVolumeValue) * 20);
    }

    public void PrepareMusicVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            ResetAllVolumes();
        }
    }
    public void PrepareSFXVolume()
    {
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            ResetAllVolumes();
        }
    }

    public void UpdateMusicVolume()
    {
        musicVolumeValue = musicSlider.value;
        musicMixer.SetFloat("Music", Mathf.Log10(musicVolumeValue) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeValue);
    }

    public void UpdateSFXVolume()
    {
        sfxVolumeValue = sfxSlider.value;
        sfxMixer.SetFloat("SFX", Mathf.Log10(sfxVolumeValue) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeValue);
    }

    public void LoadMusicVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        UpdateMusicVolume();
    }

    public void LoadSFXVolume()
    {
        StartCoroutine(MuteTestSoundWhenLoadingAudioSettings(1));
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        UpdateSFXVolume();
    }

    public IEnumerator MuteTestSoundWhenLoadingAudioSettings(float seconds)
    {
        soundTestSource.mute = true;
        yield return new WaitForSeconds(seconds);
        soundTestSource.mute = false;
    }
}
