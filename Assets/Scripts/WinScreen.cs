using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    private void OnEnable()
    {

        Debug.Log("Enable win screen");

        var timeValue = GameObject.Find("TimeValue");
        var scoreValue = GameObject.Find("ScoreValue");

        int minutes = (int)Timer.elapsedTime / 60;
        int seconds = (int)Timer.elapsedTime % 60;

        timeValue.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
        scoreValue.GetComponent<Text>().text = Scorepoints.pearlCount.ToString();

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
