using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseMenu : MonoBehaviour
{
    private bool _gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject backButton;

    public void Start()
    {
        backButton.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        Menu();
    }

    public void Resume()
    {
        backButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        backButton.SetActive(false);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Time.timeScale = 1f;
    }
}
