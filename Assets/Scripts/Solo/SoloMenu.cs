using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloMenu : MonoBehaviour
{
    private List<string> TrackList = new List<string>(){"City", "Port"}; // Track List
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
            // SET ACTIVE IMAGE CITY
            // SET INACTIVE IMAGE PORT
        }
        
        if (TrackList[i % 2] == "Port")
        {
            // SET ACTIVE IMAGE PORT
            // SET INACTIVE IMAGE CITY
        }
    }
    
    // TO BE REMOVED ??
    public void TrackSelectLeft()
    {
        i = i - 1 % TrackList.Count;
        if (TrackList[i % 2] == "City")
        {
            // SET ACTIVE IMAGE CITY
            // SET INACTIVE IMAGE PORT
        }
        
        if (TrackList[i % 2] == "Port")
        {
            // SET ACTIVE IMAGE PORT
            // SET INACTIVE IMAGE CITY
        }
    }

    public void StarGame()
    {
        SceneManager.LoadScene(TrackList[i]);
    }
}
