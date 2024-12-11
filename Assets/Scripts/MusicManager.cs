using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// MUSIC MANAGER: HANDLES THE MUSIC INTERACTION OF THE GAME
public class MusicManager : MonoBehaviour
{
    [SerializeField] [Range(0,1)] private float maxVolume; // Defines the MAXIMUM volume of ALL MUSIC
    [SerializeField] [Range(0, 1)] private float idleMinVolume; // Defines the MINIMUM volume of IDLE MUSIC ONLY
    [SerializeField] [Range(0, 1)] private float transitionSpeed; // Time between the transition between two music tracks

    // Different Music Sources listed separately
    [SerializeField] private AudioSource idleMusicSource;
    [SerializeField] private AudioSource enemyMusicSource;
    [SerializeField] private AudioSource sharkMusicSource;
    [SerializeField] private AudioSource winMusicSource;

    public SoundState soundstate; // SoundState defines which music will become to play
    public SoundStateManager soundStateManager; // SoundStateManager keeps track of the current SoundState

    // Start is called before the first frame update
    void Start()
    {
        // The current SoundState is retrieved from the SoundStateManager
        soundstate = soundStateManager.GetCurrentSoundState();
    }

    // Update is called once per frame
    void Update()
    {
        // The current SoundState is always updated from the SoundStateManager
        soundstate = soundStateManager.GetCurrentSoundState();

        // Checking the current SoundState and creating a music transition based on that
        if (soundstate == SoundState.Idle)
        {
            StartCoroutine(StartMusicTransition(idleMusicSource, transitionSpeed));
        }
        if (soundstate == SoundState.Enemy)
        {
            StartCoroutine(StartMusicTransition(enemyMusicSource, transitionSpeed));
        }
        if (soundstate == SoundState.Shark)
        {
            StartCoroutine(StartMusicTransition(sharkMusicSource, transitionSpeed));
        }
        if (soundstate == SoundState.Win)
        {
            StartCoroutine(StartMusicTransition(winMusicSource, transitionSpeed));
        }
    }

    /* StartMusicTransition:
     * BASIC STEPS: 
     * 1) all the music tracks (except the upcoming music track) will decrease to 0 (or to idleMinVolume's value if the current music is idle music)
     * 2) when each track has decreased under the certain volume (transitionBreakpoint), the checkCounter is incremented by 1
     * 3) when all the music tracks are checked, the upcoming music track will increase to maxVolume
     * RESULT: The transition between music tracks will be smooth and flexible to varying situations
     */
    IEnumerator StartMusicTransition(AudioSource upcomingMusic, float speed)
    {
        float transitionBreakpoint = idleMinVolume + 0.4f;
        AudioSource[] musictracks = { idleMusicSource, enemyMusicSource, sharkMusicSource, winMusicSource };
        int checkCounter = 0;
        
        for(int i = 0; i < musictracks.Length; i++)
        {
            float volumeIndicator = maxVolume;

            if (musictracks[i] != upcomingMusic)
            {
                musictracks[i].volume -= speed * Time.deltaTime;
                volumeIndicator = musictracks[i].volume;
            }

            if (musictracks[i] == idleMusicSource && musictracks[i].volume < idleMinVolume)
            {
                musictracks[i].volume = idleMinVolume;
            }

            if (volumeIndicator <= transitionBreakpoint || musictracks[i] == upcomingMusic)
            {
                checkCounter++;
            }

        }

        if (checkCounter == musictracks.Length && upcomingMusic.volume < maxVolume)
        {
            upcomingMusic.playOnAwake = true;
            upcomingMusic.volume += speed * Time.deltaTime;
        }
        yield return null;
    }
}