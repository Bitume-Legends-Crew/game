using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCheckpointIA : MonoBehaviour
{
    public static bool IAWin = false;
    public static bool IALost = false;

    public void Start()
    {
        IALost = false;
        IAWin = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (CompareTag("IA"))
            IAWin = true;

        if (CompareTag("Vehicle"))
            IALost = true;

    }
}
