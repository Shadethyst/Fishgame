using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private float MaxVolume;
    [SerializeField] [Range(0, 1)] private float transitionSpeed;

    [SerializeField] private AudioSource idleMusicSource;
    [SerializeField] private AudioSource enemyMusicSource;

    public State soundstate;
    public SoundStateManager soundStateManager;

    // Start is called before the first frame update
    void Start()
    {
        soundstate = soundStateManager.GetCurrentSoundState();
    }

    // Update is called once per frame
    void Update()
    {
        soundstate = soundStateManager.GetCurrentSoundState();

        if (soundstate == State.Idle)
        {
            StartCoroutine(StartMusicTransition(enemyMusicSource, idleMusicSource, transitionSpeed));
        }
        if (soundstate == State.Enemy)
        {
            StartCoroutine(StartMusicTransition(idleMusicSource, enemyMusicSource, transitionSpeed));
        }
    }

    IEnumerator StartMusicTransition(AudioSource fromSource, AudioSource toSource, float speed)
    {
        float transitionBreakpoint = (MaxVolume * 0.003f);
        fromSource.volume -= speed * Time.deltaTime;
        if (fromSource.volume < (transitionBreakpoint))
        {
            toSource.volume += speed * Time.deltaTime;
        }
        yield return null;

    }
}