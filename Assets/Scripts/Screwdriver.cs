using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Screwdriver : MonoBehaviour 
{    
    public UnityEvent onItem;
    [SerializeField] private ScrewdriverType screwdriverType;
    public enum ScrewdriverType {
        Grey
    }

    public ScrewdriverType GetScrewdriverType() {
        return screwdriverType;
    }

    private void OnTriggerEnter2D(Collider2D other) {
    Screwdriver screwdriver = GetComponent<Screwdriver>();
    if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Screwdriver"))
    {   
        Debug.Log("Player picked a screwdriver!");
        onItem.Invoke();
        gameObject.SetActive(false);
    }
    }
}
