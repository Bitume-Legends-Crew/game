using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using UnityEngine.Networking.Types;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;

    public static TextMeshProUGUI uiLevelText;
    
    // A peut être mettre en private ?
    public static int experience;
    public static int experienceToNextLevel = 200;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one LevelSystem in scene!");
            return;
        }

        instance = this;

        SetLevel(SaveManager.instance.currentLevel);
    }

    public static void AddExperience(int experienceToAdd, int multiplicator)
    {
        int formerexp = experience;
        experience += experienceToAdd * multiplicator;
        if (experience >= experienceToNextLevel)
        {
            SetLevel(SaveManager.instance.currentLevel + 1);
            experienceToNextLevel *= 2;
            NewLevel();
        }
        UpdateVisual();
        Debug.LogFormat($"former = {formerexp}, new exp = {experience}");
    }

    public static void NewLevel()
    {
        //TODO OpenPanel On Menu
    }

    public static void SetLevel(int value)
    {
        SaveManager.instance.currentLevel = value;
        experience = experience - experienceToNextLevel;
        experienceToNextLevel = (int)(50f * (Mathf.Pow(SaveManager.instance.currentLevel + 1, 2) - (5 * (SaveManager.instance.currentLevel + 1)) + 8));
        UpdateVisual();
    }

    public static void UpdateVisual()
    {
        uiLevelText.SetText(SaveManager.instance.currentLevel.ToString("0") + "\nto next lvl: " + experienceToNextLevel + "\ncurrent exp: " + experience);
    }
}

