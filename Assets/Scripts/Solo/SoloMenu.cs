using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloMenu : MonoBehaviour
{
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

    public void Track()
    {
        // Selection of the Track with SetActive
    }
    
    public void StarGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
