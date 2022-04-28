using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Photon.Pun.Demo.PunBasics.Solo
{
    public class Douille : MonoBehaviour
    {
        public Collider lastCheckpoint;

        void OnTriggerEnter(Collider other)
        {
            lastCheckpoint.gameObject.SetActive(true);
            Debug.Log("ACTIVE");
        }
    }
}