using System;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    
    private int _experience;
    private float _thresholdSup;
    private float _thresholdInf;
    private int _level;
    private readonly int _reward = 10;

    public int Level => _level;
    public float ThresholdInf => _thresholdInf;
    public float ThresholdSup => _thresholdSup;
    public int Experience => _experience;

    public void Awake()
    {
        if (instance != null)
            return;

        instance = this;
        
        _experience = SaveManager.instance.currentExp;
        _level = SaveManager.instance.currentLevel;
        _thresholdInf = (float) ((int) Math.Pow(2, _level - 1)) * 100;
        _thresholdSup = (float) Math.Pow(2, _level) * 100;
    }

    public void AddExperience(bool isWon, float coef)
    {
        int formerexp = _experience;
        _experience += (int) Math.Floor(_reward * coef * (isWon ? 1 : 0.5f));
        SaveManager.instance.currentExp = _experience;
        SaveManager.instance.Save();
        // Debug.LogFormat($"former = {formerexp}, new exp = {_experience}");
    }

    public void UpLevel()
    {
        _thresholdInf = _thresholdSup;
        _level++;
        _thresholdSup = (float) Math.Pow(2, _level) * 100;
        SaveManager.instance.currentLevel = _level;
        SaveManager.instance.Save();
    }
}

