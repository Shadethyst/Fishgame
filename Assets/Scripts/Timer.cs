using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    void Update()
{
    elapsedTime += Time.deltaTime;
    int minutes = Mathf.FloorToInt(elapsedTime / 60);
    int seconds = Mathf.FloorToInt(elapsedTime % 60);
    timerText.text = $"{minutes:00}:{seconds:00}";
}
}


