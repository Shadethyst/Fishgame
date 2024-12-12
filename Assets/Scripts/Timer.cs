using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float elapsedTime;
    public GameObject timeValue;
    private void OnEnable()
    {
        Debug.Log("Timer started");
        elapsedTime = 0;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = (int)elapsedTime/60;
        int seconds = (int)elapsedTime%60;
        timeValue.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}",minutes, seconds);
    }
}
