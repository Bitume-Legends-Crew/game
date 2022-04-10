using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;

    public TextMeshProUGUI uiLevelText;
    
    // A peut être mettre en private ?
    public int level = 0;
    public int experience;
    public int experienceToNextLevel;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one LevelSystem in scene!");
            return;
        }

        instance = this;

        SetLevel(1);
    }

    public bool AddExperience(int experienceToAdd)
    {
        experience += experienceToAdd;
        
        if (experience >= experienceToNextLevel)
        {
            SetLevel(level + 1);
            return true;
        }

        UpdateVisual();
        return false;
    }

    public void SetLevel(int value)
    {
        this.level = value;
        experience = experience - experienceToNextLevel;
        experienceToNextLevel = (int)(50f * (Mathf.Pow(level + 1, 2) - (5 * (level + 1)) + 8));
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        uiLevelText.SetText(level.ToString("0") + "\nto next lvl: " + experienceToNextLevel + "\ncurrent exp: " + experience);
    }
}

