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
    

    private void Start()
    {
        StartCoroutine(_CountDown());
    }   

    public IEnumerator _CountDown()
    {
        // LOCK CAR IN CarController
        // transform.GetChild(SaveManager.instance.currentCar).position.
        while (CountDownTimer > 0)
        {
            countDownDisplay.text = CountDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            CountDownTimer--;
        }

        countDownDisplay.text = "GO";
        yield return new WaitForSeconds(1f);
        countDownDisplay.gameObject.SetActive(false);
    }
}
