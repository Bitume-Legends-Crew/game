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
    
    public static void EarnXP()
    {
        if (GameEnded())
        {
            for (int i = 0; i < PlayerList.Length; i++)
            {
                RaceScript.playerTag = PlayerList[i].UserId;
                if (i == 0)
                    LevelSystem.AddExperience(100);
                
                else if (i == 1)
                    LevelSystem.AddExperience(85);
                
                else if (i == 2)
                    LevelSystem.AddExperience(65);
                
                else
                    LevelSystem.AddExperience(50);
            }
        }
    }
    
}
