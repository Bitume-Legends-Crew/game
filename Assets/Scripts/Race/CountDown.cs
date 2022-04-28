using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using NWH;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public static int CountDownTimer;
    public Text countDownDisplay;
    public GameObject SceneManagement;
    

    private void Start()
    {
        StartCoroutine(_CountDown());
    }   

    public IEnumerator _CountDown()
    {
        while (CountDownTimer > 0)
        {
            SceneManagement.SetActive(false);
            if (CountDownTimer == 1)
                SceneManagement.SetActive(true);
            
            countDownDisplay.text = CountDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            CountDownTimer--;
            
        }
        
        countDownDisplay.text = "GO";
        yield return new WaitForSeconds(1f);
        countDownDisplay.gameObject.SetActive(false);
    }
}
