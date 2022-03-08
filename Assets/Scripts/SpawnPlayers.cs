using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using static System.Random;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject playerCamera;

    public Transform[] spawnPositions;

    private PhotonView _view;
    private void Awake()
    {
        _view = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject myCar = (GameObject) PhotonNetwork.Instantiate(playerPrefab.name,
            spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber].position, Quaternion.identity);
        myCar.gameObject.SetActive(true);
        Debug.LogFormat($"Spawn Player {PhotonNetwork.LocalPlayer.ActorNumber}");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Quit()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }
}