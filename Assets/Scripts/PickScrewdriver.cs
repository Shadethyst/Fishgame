using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class PickScrewdriver : MonoBehaviour
{

    public UnityEvent OnDamageTaken;
    public int sdCount;
    public Text sdText;
    public GameObject door;
    private bool doorDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sdText.text = sdCount.ToString();
        if(sdCount == 1)
        {
            Destroy(door);
        }
    }


    private void OnTriggerEnter2D(Collider2D Screwdriver)
    {
        if (Screwdriver.gameObject.tag.Equals("Player"))
        {
            OnDamageTaken.Invoke();
            Debug.Log("Player picked Screwdriver!");
        }
        

    }

}
