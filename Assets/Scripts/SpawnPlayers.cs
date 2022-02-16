using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static System.Random;

public class SpawnPlayers : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject playerCamera;
    public Transform[] spawnPositions;


    public int minX;
    public int maxX;
    public int minY;
    public int maxY;
    
    // Start is called before the first frame update
    void Start() {
        //position spawning
        // Vector3 spawnPosition = new Vector3(0, 0, -7); 
        // PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
        
        //Vector3 cameraPosition = new Vector3(spawnPosition.x, (float) (spawnPosition.y + 3.21),(spawnPosition.z - 6));
        //PhotonNetwork.Instantiate(playerCamera.name, cameraPosition, Quaternion.identity);
        //Debug.Log("SpawnPlayers.Start launched...");
        StartCoroutine(SpawnMyPlayer());
    }

    IEnumerator SpawnMyPlayer()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (Equals(PhotonNetwork.PlayerList[i], PhotonNetwork.LocalPlayer))
            {
                PhotonNetwork.Instantiate(playerPrefab.name,
                    spawnPositions[i].position, Quaternion.identity);
            }
        }
        // PhotonNetwork.Instantiate(playerPrefab.name, spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber].position, Quaternion.identity);
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
