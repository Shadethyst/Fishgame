using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    [SerializeField] private Image totalhealtBar;
    [SerializeField] private Image currenthealtBar;

    private void Start()
    {
        totalhealtBar.fillAmount = health.currenthealth;
    }

    private void Update()
    {
        currenthealtBar.fillAmount = health.currenthealth /3;
    }
    
}
