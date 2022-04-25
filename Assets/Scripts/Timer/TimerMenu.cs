using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerMenu : MonoBehaviour
{
    private List<string> TrackList = new List<string>(){"Timer_City", "Timer_Port"}; // Track List
    private int i = 0; // Index for list
    private bool setDifficulty = false;
    public GameObject Error;
    public GameObject CityImage;
    public GameObject PortImage;
    

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void DifficultyEasy()
    {
        TimerMode.startingTime = 90f;
        setDifficulty = true;
        Error.SetActive(false);
    }
    
    public void DifficultyMedium()
    {
        TimerMode.startingTime = 60f;
        setDifficulty = true;
        Error.SetActive(false);
    }
    
    public void DifficultHard()
    {
        TimerMode.startingTime = 5f;
        setDifficulty = true;
        Error.SetActive(false);
    }

    public void TrackSelectRight()
    {
        i = (i + 1) % TrackList.Count;
        if (TrackList[i % 2] == "Timer_City")
        {
            CityImage.SetActive(true);
            PortImage.SetActive(false);
        }
        
        if (TrackList[i % 2] == "Timer_Port")
        {
            CityImage.SetActive(false);
            PortImage.SetActive(true);
        }
    }

    public void StarGame()
    {
        // If difficulty Not set
        if (setDifficulty)
            SceneManager.LoadScene(TrackList[i]);
        
        else
            Error.SetActive(true);
            
    }
}
