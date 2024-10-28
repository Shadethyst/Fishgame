using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health = 3;
    // Start is called before the first frame update


    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health changed to: " + health);
    }
}
