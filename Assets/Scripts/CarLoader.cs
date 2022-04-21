using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLoader : MonoBehaviour
{
   [SerializeField] private GameObject[] carModels;

   private void Awake()
   {
      ChooseCarModels(SaveManager.instance.currentCar);
   }

   private void ChooseCarModels(int _index)
   {
      Instantiate(carModels[_index], transform.position, Quaternion.identity, transform);
   }
}
