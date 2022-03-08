using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static System.Random;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject playerCamera;
    public static GameObject LocalPlayerInstance;

    public static Transform[] spawnPositions;
    // public List<bool> _isFree = new List<bool>();


    // public int minX;
    // public int maxX;
    // public int minY;
    // public int maxY;


    // private void Awake()
    // {
    //     if (photonView.IsMine)
    //     {
    //         SpawnPlayers.LocalPlayerInstance = this.gameObject;
    //     }
    //
    //     DontDestroyOnLoad(this.gameObject);
    // }

    void Start()
    {
        #region former
        // for (int i = 0; i < spawnPositions.Length; i++)
        // {
        //     _isFree.Add(true);
        // }
        //position spawning
        // Vector3 spawnPosition = new Vector3(0, 0, -7); 
        // PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);

        //Vector3 cameraPosition = new Vector3(spawnPosition.x, (float) (spawnPosition.y + 3.21),(spawnPosition.z - 6));
        //PhotonNetwork.Instantiate(playerCamera.name, cameraPosition, Quaternion.identity);
        //Debug.Log("SpawnPlayers.Start launched...");

        // StartCoroutine(SpawnMyPlayer());
        #endregion

        #region added
        // if (LocalPlayerInstance == null)
        // {
        //     Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
        //     Debug.LogFormat($"Player {PhotonNetwork.NickName} instantiate at {PhotonNetwork.LocalPlayer.ActorNumber}");
        //     PhotonNetwork.Instantiate(playerPrefab.name, spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber].position,
        //         Quaternion.identity);
        // }
        // else
        // {
        //     Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
        // }
        #endregion
        
        Debug.Log($"Player {PhotonNetwork.NickName} instantiate at {PhotonNetwork.LocalPlayer.ActorNumber}");
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber].position,
            Quaternion.identity);
    }

    IEnumerator SpawnMyPlayer()
    {
        // for (int i = 0; i < _isFree.Count; i++)
        // {
        //     if (_isFree[i])
        //     {
        //         PhotonNetwork.Instantiate(playerPrefab.name,
        //             spawnPositions[i].position, Quaternion.identity);
        //         
        //     }
        // }
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber].position,
            Quaternion.identity);
        yield return new WaitForSeconds(5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Quit()
    {
        Application.Quit();
    }
}