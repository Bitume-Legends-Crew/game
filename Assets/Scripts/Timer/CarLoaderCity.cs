using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class CarLoaderCity : MonoBehaviour
{
   [SerializeField] private GameObject[] carModels;

   private void Awake()
   {
      ChooseCarModels(SaveManager.instance.currentCar);
   }

   private void ChooseCarModels(int _index)
   {
      Quaternion quaternion = Quaternion.identity;
      quaternion.y = 90;
      quaternion.w = 90;
      Instantiate(carModels[_index], transform.position, quaternion, transform);
   }
}
