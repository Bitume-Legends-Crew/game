using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RaceScript : MonoBehaviour
{
    public static string playerTag = "playerTagExemple"; // to recognize the player (via tag) 
    public static int lapCounter; // to count laps
    public static int maxNbOfLap; // set how many lap the player has to run before end
    public static Player[] PlayerList = PhotonNetwork.PlayerList; // List of Player in the Room

    public static void Start()
    {
        Initialization();
    }

    // If Hos Player Has Joined the Game
    public static bool HostJoined()
    {
        if (PlayerList.Length == SpawnPlayers.spawnPositions.Length)
            return true;

        return false;
    }

    // To set the initial state of racce
    public static void Initialization()
    {
        lapCounter = 0; // actual lap done
        maxNbOfLap = 3; // Needed lap to win
    }


    // When the player Trigger the box collider at the start/finish line
    /// <param name="objectWhichPassTheLine"></param>
    public static void OnTriggerEnter(Collider objectWhichPassTheLine)
    {
        if (objectWhichPassTheLine.gameObject.CompareTag(playerTag))
        {
            lapCounter++;
        }

        IsFinished();
    }


    // Check the lap counter to see how many lap the player did
    public static bool IsFinished()
        // +1 because the player will trigger the collider at the start.
        => lapCounter == maxNbOfLap + 1; 


    // You end the race when the player reach the max number of lap.
    public static void EndGame()
    {
        // We have to STOP the game
        Debug.Log("The game is ended, the player did 3 lap");
        Initialization();
    }
}