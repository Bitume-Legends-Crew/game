using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Text TxtSpeed;

    void Update()
    {
        float Speed = GetComponentInChildren<Rigidbody>().velocity.magnitude * 3.6f;
        TxtSpeed.text = (int)Speed + " Km/h";
    }
}
