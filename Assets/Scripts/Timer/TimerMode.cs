using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class TimerMode : MonoBehaviour
{
    public static int passedCheckpoint;
    private float currentTime = 0f;
    public static float startingTime;
    public Text countDownText;

    public BoxCollider[] Checkpoint;
    // public AudioSource timeAudio;
    // public GameObject Car;

    public GameObject TextWin;
    public GameObject TextLoose;
    public GameObject BackGroundWin;
    public GameObject BackGroundLoose;
    public GameObject ButtonRetry;
    public GameObject ButtonMenu;
    public GameObject ButtonBack;

    private void Start()
    {
        CountDown.CountDownTimer = 3;
        currentTime = startingTime;
        passedCheckpoint = 0;
        Destroy(MusicHandler.musicObj[0]);
        LastCheckpoint.PassedLastCheckpointPlayer = false;
        LastCheckpoint.PassedLastCheckpointPlayer = false;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Start();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;
        Start();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;
        Start();
    }


    public void Win()
    {
        passedCheckpoint = 0;
        TextWin.SetActive(true);
        BackGroundWin.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
        switch (startingTime)
        {
            case 90f:
                LevelSystem.instance.AddExperience(true, 1f);
                break;
            case 70f:
                LevelSystem.instance.AddExperience(true, 1.5f);
                break;
            case 63f:
                LevelSystem.instance.AddExperience(true, 2f);
                break;
        }
    }

    public void Loose()
    {
        // timeAudio.Play();
        passedCheckpoint = 0;
        currentTime = 0;
        TextLoose.SetActive(true);
        BackGroundLoose.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
        switch (startingTime)
        {
            case 90f:
                LevelSystem.instance.AddExperience(false, 1f);
                break;
            case 70f:
                LevelSystem.instance.AddExperience(false, 1.5f);
                break;
            case 63f:
                LevelSystem.instance.AddExperience(false, 2f);
                break;
        }
    }


    private void Update()
    {
        if (CountDown.CountDownTimer == 0)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = "Remaining Time: " + currentTime.ToString("0") + " sec.";

            if (currentTime <= 0)
                Loose();

            else if (currentTime >= 0 && LastCheckpoint.PassedLastCheckpointPlayer &&
                     passedCheckpoint >= Checkpoint.Length + 1)
                Win();
        }
    }
}