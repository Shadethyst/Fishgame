using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class Scorepoints : MonoBehaviour
{
    public static int pearlCount = 0;

    public Text pearlText;
    public UnityEvent Scored;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pearlText.text = pearlCount.ToString();
        
    }

    public void pearlAdded(){
        pearlCount++;
        if (pearlCount%10 == 0)
        {
            Scored.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D Pearl)
    {
        if (Pearl.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player picked pearl!");
        }
        

    }

}

