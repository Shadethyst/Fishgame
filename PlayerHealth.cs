using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float health = 3;
    public Text healthText;
    public GameObject gameOverScreen;
    public bool fishIsAlive = true;
    // Start is called before the first frame update


    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }
    void Start()
{
    if (healthText == null)
    {
        Debug.LogError("HealthText is not assigned!");
    }
}


    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        if(health <= 0)
        {
            gameOver();
            fishIsAlive = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health changed to: " + health);
    }
    public void addHealth(float healing)
    {
        if(health < 5)
        {
            health += healing;
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
