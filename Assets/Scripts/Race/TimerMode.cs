using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TimerMode : MonoBehaviour
{
    public static int passedCheckpoint = 0;
    private float currentTime = 0f;
    public static float startingTime;
    public Text countDownText;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    public BoxCollider[] Checkpoint;
    // public AudioSource timeAudio;
    // public GameObject Car;
    
    public Button Retry;
    public Button Menu;
    public GameObject Back;

    private void Start()
    {
        CountDown.CountDownTimer = 3;
        currentTime = startingTime;
        Destroy(MusicHandler.musicObj[0]);;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BackMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    private void Update()
    {
        if (CountDown.CountDownTimer == 0)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = "Remaining Time: " + currentTime.ToString("0") + " sec.";

            if (currentTime <= 0)
            {
                currentTime = 0;
                // timeAudio.Play();
                gameOverPanel.SetActive(true);
                Back.SetActive(false);
                Time.timeScale = 0f;
            }
            
            else if (currentTime >= 0 && Checkpoint.Length == passedCheckpoint)
            {
                // timeAudio.Play();
                gameWinPanel.SetActive(true);
                Back.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
}
