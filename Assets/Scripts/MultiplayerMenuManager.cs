using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                OpenMenu(_menus[i]);
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
}