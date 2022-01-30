using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }
    public InputController InputController { get; private set; }

    void Awake()
    {
        Instance = this;
        InputController = GetComponentInChildren<InputController>();
    }
    
    void Update()
    {
        
    }
}
