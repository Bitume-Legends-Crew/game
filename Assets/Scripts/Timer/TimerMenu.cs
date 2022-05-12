using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerMenu : MonoBehaviour
{
    private List<string> TrackList = TrackPossible.TimerTrack; // Track List
    private int i = 0; // Index for list
    private bool setDifficulty = false;
    public GameObject error;
    public GameObject cityImage;
    public GameObject portImage;
    public GameObject loadingScreen;


    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void DifficultyEasy()
    {
        TimerMode.startingTime = 90f;
        setDifficulty = true;
        error.SetActive(false);
    }

    public void DifficultyMedium()
    {
        TimerMode.startingTime = 70f;
        setDifficulty = true;
        error.SetActive(false);
    }

    public void DifficultHard()
    {
        TimerMode.startingTime = 63f;
        setDifficulty = true;
        error.SetActive(false);
    }

    public void TrackSelectRight()
    {
        i = (i + 1) % TrackList.Count;
        if (TrackList[i % 2] == "Timer_City")
        {
            cityImage.SetActive(true);
            portImage.SetActive(false);
        }

        if (TrackList[i % 2] == "Timer_Port")
        {
            cityImage.SetActive(false);
            portImage.SetActive(true);
        }
    }

    public void StarGame()
    {
        // If difficulty Not set
        if (setDifficulty)
        {
            loadingScreen.SetActive(true);
            SceneManager.LoadScene(TrackList[i]);
        }

        else
            error.SetActive(true);
    }
}