using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastChekpointIA : MonoBehaviour
{
    public static bool PassedLastCheckpointIA = false;
    public bool FirstPass;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vehicle")
        {
            if (!FirstPass)
                FirstPass = true;
            
            if(FirstPass)
                PassedLastCheckpointIA = true;
        }
    }
}
