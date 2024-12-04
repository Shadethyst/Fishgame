using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrewdriverBar : MonoBehaviour
{
    [SerializeField] private PickScrewdriver sd;
    [SerializeField] private Image totalsd;
    [SerializeField] private Image currentsd;

    private void Start()
    {
        totalsd.fillAmount = sd.sdCount;
    }
    
    private void Update()
    {
        currentsd.fillAmount = sd.sdCount;
    }
    
}