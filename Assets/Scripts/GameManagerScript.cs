using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class GameManagerScript : MonoBehaviourPunCallbacks
{
    public static GameManagerScript Instance;
    public GameObject playerPrefab;

    private void Start()
    {
        Instance = this;
        if (playerPrefab == null)
        {
            Debug.LogError(
                "<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",
                this);
        }
        else
        {
            if (SpawnPlayers.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                PhotonNetwork.Instantiate(this.playerPrefab.name,
                    SpawnPlayers.spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber].position,
                    Quaternion.identity, 0);
            }
            
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            }
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(1);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadTrack()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }

        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("Scene1");
    }


    #region former
    // public static GameManagerScript Instance { get; private set; }
    // public InputController InputController { get; private set; }
    //
    // void Awake()
    // {
    //     Instance = this;
    //     InputController = GetComponentInChildren<InputController>();
    // }
    //
    // void Update()
    // {
    // }
    #endregion
    
}