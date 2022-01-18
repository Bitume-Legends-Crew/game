using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static System.Random;

public class SpawnPlayers : MonoBehaviour {
    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    
    // Start is called before the first frame update
    void Start() {
        Vector3 randomPosition = new Vector3(0, 0, 0); //Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        Debug.Log("SpawnPlayers.Start launched...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
