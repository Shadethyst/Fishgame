using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public CanvasGroup OptionPanel;
    public CanvasGroup StoryPanel;

    [SerializeField] private GameObject[] storyPages;

    [SerializeField] private GameObject previousPageButton;
    [SerializeField] private GameObject nextPageButton;

    private int storyPageCounter;
    private GameObject activeStoryPage;


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Story()
    {
        StoryPanel.alpha = 1;
        StoryPanel.blocksRaycasts = true;
        activeStoryPage = storyPages[0];
        storyPageCounter = 0;

        activeStoryPage.GetComponent<Image>().enabled = true;

        for (int i = 0; i < storyPages.Length; i++)
        {
            if (storyPages[i] != activeStoryPage)
            {
               storyPages[i].GetComponent<Image>().enabled = false;
            }
        }

        nextPageButton.GetComponent<Image>().enabled = true;
        previousPageButton.GetComponent<Image>().enabled = false;
    }

    public void NextStoryPage()
    {
        storyPageCounter++;

        if (storyPageCounter < storyPages.Length)
        {
            nextPageButton.GetComponent<Image>().enabled = true;
            activeStoryPage.GetComponent<Image>().enabled = false;
            activeStoryPage = storyPages[storyPageCounter];
            activeStoryPage.GetComponent<Image>().enabled = true;
        }

        if (storyPageCounter == storyPages.Length - 1)
        {
           nextPageButton.GetComponent<Image>().enabled = false;
        }

        if (storyPageCounter > 0)
        {
            previousPageButton.GetComponent<Image>().enabled = true;
        }

    }

    public void PreviousStoryPage()
    {
        if (storyPageCounter > 0)
        {
            storyPageCounter--;
            activeStoryPage.GetComponent<Image>().enabled = false;
            activeStoryPage = storyPages[storyPageCounter];
            activeStoryPage.GetComponent<Image>().enabled = true;
        }
        if (storyPageCounter <= 0)
        {
            previousPageButton.GetComponent<Image>().enabled = false;
        }
        if (storyPageCounter <= storyPages.Length - 1)
        {
            nextPageButton.GetComponent<Image>().enabled = true; 
        }
        
    }


    public void Settings()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
    }

    public void Back()
    {
        StoryPanel.alpha = 0;
        StoryPanel.blocksRaycasts = false;
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
