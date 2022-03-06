using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerMenuManager : MonoBehaviour
{
    public static MultiplayerMenuManager Instance;

    [SerializeField] Loader[] menus;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].Open();
            }

            else if (menus[i].open && menus[i].menuName != "Background")
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Loader menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open && menus[i].menuName != "Background")
            {
                CloseMenu(menus[i]);
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