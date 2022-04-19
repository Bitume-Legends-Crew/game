using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MultiplayerMenuManager : MonoBehaviour
{
    public static MultiplayerMenuManager Instance;

    [SerializeField] Loader[] _menus;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            if (_menus[i].menuName == menuName)
            {
                _menus[i].Open();
            }

            else if (_menus[i].open && _menus[i].menuName != "Background")
            {
                CloseMenu(_menus[i]);
            }
        }
    }

    public void OpenMenu(Loader menu)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            if (_menus[i].open && _menus[i].menuName != "Background")
            {
                CloseMenu(_menus[i]);
            }
        }

        menu.Open();
    }

    public void CloseMenu(Loader menu)
    {
        menu.Close();
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void BackToMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Menu");
    }
}