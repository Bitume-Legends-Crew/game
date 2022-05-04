using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCheckpointIA : MonoBehaviour
{
    public static bool PassedLastCheckpointIA = false;
    public bool FirstPass;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IA")
        {
            if (!FirstPass)
                FirstPass = true;
            
            else
                PassedLastCheckpointIA = true;
        }
    }
}
