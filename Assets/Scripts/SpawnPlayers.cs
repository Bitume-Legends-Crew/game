using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static System.Random;

public class SpawnPlayers : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject playerCamera;

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;
    
    // Start is called before the first frame update
    void Start() {
        //RandomPosition position spawning
        Vector3 randomPosition = new Vector3(0, 0, -7); //Random.Range(minX, maxX), 0, Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        // Vector3 cameraPosition = new Vector3(randomPosition.x, (float) (randomPosition.y + 3.21),
        //      (randomPosition.z - 6));
        // PhotonNetwork.Instantiate(playerCamera.name, cameraPosition, Quaternion.identity);
        // Debug.Log("SpawnPlayers.Start launched...");
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
