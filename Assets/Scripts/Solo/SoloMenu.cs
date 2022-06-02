using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloMenu : MonoBehaviour
{
    private List<string> TrackList = TrackPossible.SoloTrack; // Track List
    private int i = 0; // Index for list
    private bool setDifficulty = false;
    public GameObject error;
    public GameObject cityImage;
    public GameObject portImage;
    public static int Difficulty;
    public GameObject loadingScreen;

    public void Back()
    {
        SceneManager.LoadScene("Menu");
        setDifficulty = false;
    }

    public void DifficultyEasy()
    {
        // Load Easy Difficulty with I.A.
        setDifficulty = true;
        Difficulty = 1;
    }

    public void DifficultyMedium()
    {
        // Load Medium Difficulty with I.A.
        setDifficulty = true;
        Difficulty = 2;
    }

    public void DifficultHard()
    {
        // Load Hard Difficulty with I.A.
        setDifficulty = true;
        Difficulty = 3;
    }

    public void TrackSelectRight()
    {
        i = (i + 1) % TrackList.Count;
        if (TrackList[i % 2] == "City_AI")
        {
            cityImage.SetActive(true);
            portImage.SetActive(false);
        }

        if (TrackList[i % 2] == "Port_AI")
        {
            cityImage.SetActive(false);
            portImage.SetActive(true);
        }
    }

    public void StarGame()
    {
        if (setDifficulty)
        {
            loadingScreen.SetActive(true);
            SceneManager.LoadScene(TrackList[i]);
        }

        else
            error.SetActive(true);
    }
}