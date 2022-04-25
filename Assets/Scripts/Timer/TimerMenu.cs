using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerMenu : MonoBehaviour
{
    private List<string> TrackList = new List<string>(){"Timer_City", "Timer_Port"}; // Track List
    private int i = 0; // Index for list

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void DifficultyEasy()
    {
        // Load Easy Difficulty with I.A.
    }
    
    public void DifficultyMedium()
    {
        // Load Medium Difficulty with I.A.
    }
    
    public void DifficultHard()
    {
        // Load Hard Difficulty with I.A.
    }

    public void TrackSelectRight()
    {
        i = (i + 1) % TrackList.Count;
        if (TrackList[i % 2] == "City")
        {
            GameObject.Find("City_Image").SetActive(true);
            GameObject.Find("Port_Image").SetActive(false);
        }
        
        if (TrackList[i % 2] == "Port")
        {
            GameObject.Find("Port_Image").SetActive(true);
            GameObject.Find("City_Image").SetActive(false);
        }
    }

    public void StarGame()
    {
        SceneManager.LoadScene(TrackList[i]);
    }
}
