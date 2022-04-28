using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastChekpointIA : MonoBehaviour
{
    public static bool PassedLastCheckpointIA;
    public bool FirstPass;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (CompareTag("IA"))
        {
            if (!FirstPass)
                FirstPass = true;
            
            else
                PassedLastCheckpointIA = true;
        }
    }
}
