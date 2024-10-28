using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health = 3;
    delegate void OnPlayerDeath();
    delegate void OnPlayerHealthChanged();
    delegate void OnDamageTaken();
    OnDamageTaken onDamageTaken;
    // Start is called before the first frame update


    private void OnEnable()
    {
        onDamageTaken += TakeDamage;
    }
    private void OnDisable()
    {
        onDamageTaken -= TakeDamage;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamage()
    {
        health -= 1;
    }
}
