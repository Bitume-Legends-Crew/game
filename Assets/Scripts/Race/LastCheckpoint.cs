using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LastCheckpoint : MonoBehaviour
{
    public static bool PassedLastCheckpointPlayer = false;
    public bool FirstPass;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vehicle")
        {
            if (!FirstPass)
                FirstPass = true;
            
            if(FirstPass)
                PassedLastCheckpointPlayer = true;
        }
    }
}
