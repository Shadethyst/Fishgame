using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrewdriverHolder : MonoBehaviour
{
    private List<Screwdriver.ScrewdriverType> screwdriverList;

    private void Awake() {
        screwdriverList = new List<Screwdriver.ScrewdriverType>();
    }

    public void AddScrewdriver(Screwdriver.ScrewdriverType screwdriverType) {
        Debug.Log("Added Screwdriver:" + screwdriverType);
        screwdriverList.Add(screwdriverType);
    }

    public void RemoveScrewdriver(Screwdriver.ScrewdriverType screwdriverType) {
        screwdriverList.Remove(screwdriverType);
    }

    public bool ContainsScrewdriver(Screwdriver.ScrewdriverType screwdriverType) {
        return screwdriverList.Contains(screwdriverType);
    }
}
