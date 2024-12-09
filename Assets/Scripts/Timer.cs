using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float elapsedTime;

    private void OnEnable()
    {
        Debug.Log("Timer started");
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        //int minutes = elapsedTime/60;
        //int seconds = elapsedTime%60;
        //timerText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
    }
}
