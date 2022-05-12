using System;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    private int _currentCar;

    private void Start()
    {
        _currentCar = SaveManager.instance.currentCar;
        SelectCar(_currentCar);
    }
    
     private void SelectCar(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == index % transform.childCount);
    }  
     
    public void ChangeCar(int change)
    {
        _currentCar = (_currentCar + change) % transform.childCount;
        
        if (_currentCar < 0)
            _currentCar = transform.childCount - _currentCar;
        
        SaveManager.instance.currentCar = _currentCar;
        SaveManager.instance.Save();
        SelectCar(_currentCar);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            ChangeCar(-1);
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            ChangeCar(1);
    }
}
