using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static Player[] PlayerList = PhotonNetwork.PlayerList;

    // START GAME

    private void Start()
    {
        RaceScript.Start();
    }

    // UPDATE GAME


    // END GAME

    public static bool GameEnded()
    {
        foreach (Player player in PlayerList)
        {
            RaceScript.playerTag = player.UserId;
            if (!RaceScript.IsFinished())
                return false;
        }

        return true;
    }

    // EARN XP
}