using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float currenthealth;
    [SerializeField] public float startinghealth = 3;
    public Image healthImage;
    public GameObject gameOverScreen;
    public bool fishIsAlive = true;
    // Start is called before the first frame update


    private void Awake()
    {
        currenthealth = startinghealth;
    }

    public void TakeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, startinghealth);
        
        if (currenthealth > 0)
        {
            //hurt
        }
        else
        {
            gameOver();
            fishIsAlive = false;
        }
    }
       public void addHealth(float healing)
    {
        if(currenthealth < 3)
        {
            currenthealth += healing;
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
