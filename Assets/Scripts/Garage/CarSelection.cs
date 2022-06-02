using System;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    private int _currentCar;
    [SerializeField] private GameObject[] specs;
    [SerializeField] private GameObject lockPanel;

    private void Start()
    {
        _currentCar = SaveManager.instance.currentCar;
        SelectCar(_currentCar);
    }

    private void SelectCar(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == index % transform.childCount);
        if (_currentCar > LevelSystem.instance.Level)
        {
            lockPanel.SetActive(true);
            foreach (var spec in specs)
                spec.SetActive(false);
        }

        else
        {
            lockPanel.SetActive(false);
            for (int i = 0; i < specs.Length; i++)
                specs[i].SetActive(i == _currentCar % specs.Length);
        }
    }

    public void ChangeCar(int change)
    {
        _currentCar = (_currentCar + change) % 5;

        if (_currentCar < 0)
            _currentCar = 5 + _currentCar;

        SaveManager.instance.currentCar =
            _currentCar <= LevelSystem.instance.Level ? _currentCar : SaveManager.instance.currentCar;
        SaveManager.instance.Save();
        SelectCar(_currentCar);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
            ChangeCar(-1);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            ChangeCar(1);
    }
}