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
        // timeAudio.Play();
        passedCheckpoint = 0;
        TextWin.SetActive(true);
        BackGroundWin.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
        switch (SoloMenu.Difficulty)
        {
            case 1:
                LevelSystem.AddExperience(5,2);
                break;
            case 2:
                LevelSystem.AddExperience(7,2);
                break;
            case 3:
                LevelSystem.AddExperience(10,2);
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
        switch (SoloMenu.Difficulty)
        {
            case 1:
                LevelSystem.AddExperience(5,1);
                break;
            case 2:
                LevelSystem.AddExperience(7,1);
                break;
            case 3:
                LevelSystem.AddExperience(10,1);
                break;
        }
    }

    

    private void Update()
    {
        if (CountDown.CountDownTimer == 0)
        {
            Debug.Log(passedCheckpoint);
            
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = "Remaining Time: " + currentTime.ToString("0") + " sec.";

            if (currentTime <= 0)
            {
                Loose();
            }
            
            else if (currentTime >= 0 && LastCheckpoint.PassedLastCheckpointPlayer && passedCheckpoint >= Checkpoint.Length + 1)
            {
                Win();
            }
        }
    }
}
