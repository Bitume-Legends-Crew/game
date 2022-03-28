using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript1 : MonoBehaviour
{
    public static GameManagerScript1 Instance { get; private set; }
    public InputController1 InputController { get; private set; }

    void Awake()
    {
        Instance = this;
        InputController = GetComponentInChildren<InputController1>();
    }
    
    void Update()
    {
        
    }
}
