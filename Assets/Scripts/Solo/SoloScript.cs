using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class SoloScript : MonoBehaviour
{
    public static int passedCheckpoint;
    private float currentTime = 0f;
    public BoxCollider[] Checkpoint;
    public static int IApassedCheckpoint = AIController._i;
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
        passedCheckpoint = 0;
        Destroy(MusicHandler.musicObj[0]);
        LastChekcpoint.PassedLastCheckpointPlayer = false;
        PortCheckpointIA.IALost = false;
        PortCheckpointIA.IAWin = false;
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        IApassedCheckpoint = 0;
        Start();
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;
        IApassedCheckpoint = 0;
        Start();
    }
    
    public void BackMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;
        IApassedCheckpoint = 0;
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
        IApassedCheckpoint = 0;
        Time.timeScale = 0f;
    }

    public void Loose()
    {
        // timeAudio.Play();
        passedCheckpoint = 0;
        currentTime = 0;
        TextLoose.SetActive(true);
        BackGroundLoose.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonBack.SetActive(false);
        IApassedCheckpoint = 0;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        
        if ((LastChekpointIA.PassedLastCheckpointIA && IApassedCheckpoint > Checkpoint.Length && passedCheckpoint <= Checkpoint.Length + 1) || PortCheckpointIA.IAWin)
        {
            Loose();
            Time.timeScale = 0f;
        }
        
        if ((passedCheckpoint >= Checkpoint.Length + 1 && LastChekcpoint.PassedLastCheckpointPlayer) || PortCheckpointIA.IALost)
        {
            Win();
            Time.timeScale = 0f;
        }
    }
}
