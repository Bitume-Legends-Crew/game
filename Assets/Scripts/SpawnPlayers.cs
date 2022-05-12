using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static System.Random;

public class SpawnPlayers : MonoBehaviour {
    [SerializeField] private Transform[] spawnPositions;
    public Transform[] SpawnPositions => spawnPositions;
    
    private void Start()
    {
        Debug.Log(spawnPositions.Length);
    }
    // public List<bool> _isFree = new List<bool>();


    // public int minX;
    // public int maxX;
    // public int minY;
    // public int maxY;
    
    // Start is called before the first frame update
    // void Start() {
    //     // for (int i = 0; i < spawnPositions.Length; i++)
    //     // {
    //     //     _isFree.Add(true);
    //     // }
    //     //position spawning
    //     // Vector3 spawnPosition = new Vector3(0, 0, -7); 
    //     // PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    //     
    //     //Vector3 cameraPosition = new Vector3(spawnPosition.x, (float) (spawnPosition.y + 3.21),(spawnPosition.z - 6));
    //     //PhotonNetwork.Instantiate(playerCamera.name, cameraPosition, Quaternion.identity);
    //     //Debug.Log("SpawnPlayers.Start launched...");
    //     
    //     // StartCoroutine(SpawnMyPlayer());
    //     PhotonNetwork.Instantiate(playerPrefab.name, spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber].position,
    //         Quaternion.identity);
    // }
    
}
