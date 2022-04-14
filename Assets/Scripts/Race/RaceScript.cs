using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceScript : MonoBehaviour
{
    string playerTag = "playerTagExemple"; // to recognize the player (via tag) 
    int lapCounter; // to count laps
    int maxNbOfLap; // set how many lap the player has to run before end

    void Start()
    {
        initialization();
    }

 
    // To set the initial state of racce
    void initialization()
    {
        lapCounter = 0; // actual lap done
        maxNbOfLap = 3; // Needed lap to win
    }


    // When the player Trigger the box collider at the start/finish line
    /// <param name="_objectWhichPassTheLine"></param>
    void OnTriggerEnter(Collider _objectWhichPassTheLine)
    {
        if (_objectWhichPassTheLine.gameObject.CompareTag(playerTag))
        {
            lapCounter++;  
        }
        checkLapCounter();
    }


    // Check the lap counter to see how many lap the player did
    void checkLapCounter()
    {
        if (lapCounter == maxNbOfLap + 1) // +1 because the player will trigger the collider at the start.
        {
            endGame();
        }
    }


    // You end the race when the player reach the max number of lap.
    void endGame()
    {
        // We have to STOP the game
        Debug.Log("The game is ended, the player did 3 lap");
        initialization();
    }

}
