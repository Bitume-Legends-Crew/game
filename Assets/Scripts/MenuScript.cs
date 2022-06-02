using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject optionMenu;
    public Text levelText;
    public GameObject levelUp;
    public Slider expLevel;
    public Text levelUpText;
    public GameObject playerMenu;

    public void Timer()
        => SceneManager.LoadScene("Timer");

    public void Multiplayer()
        => SceneManager.LoadScene("Lobby");

    public void Soloplayer()
        => SceneManager.LoadScene("Solo");

    public void Garage()
        => SceneManager.LoadScene("Garage");

    public void QuitGame()
        => Application.Quit();

    public void BugReport()
        => Application.OpenURL(
            "https://docs.google.com/forms/d/e/1FAIpQLSdtMqQPdZ3fohHimmtKlI6b1E8ZpBkLsoX8qXae7XPpkvpLcQ/viewform?usp=pp_url");

    public void OpenOptions()
        => optionMenu.SetActive(true);

    public void PlayerMenu()
        => playerMenu.SetActive(true);

    private void LevelUp()
    {
        if (LevelSystem.instance.Level > 4)
            return;
        
        levelUp.SetActive(true);
        LevelSystem.instance.UpLevel();
        levelUpText.text = $"New level passed! you are now Level {LevelSystem.instance.Level}!";
        InitSlider();
    }

    void InitSlider()
    {
        expLevel.minValue = LevelSystem.instance.ThresholdInf;
        expLevel.maxValue = LevelSystem.instance.ThresholdSup;
        expLevel.value = LevelSystem.instance.Experience;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToMenu();
        if (LevelSystem.instance.Experience >= LevelSystem.instance.ThresholdSup)
            LevelUp();
        InitSlider();
    }

    private void Start()
    {
        levelText.text = "Level " + LevelSystem.instance.Level;
        levelUp.SetActive(false);
        optionMenu.SetActive(false);
    }

    public void BackToMenu()
        => levelUp.SetActive(false);
}