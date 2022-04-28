using System;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    public BoxCollider[] checkpoints;
    public NavMeshAgent agent;
    public static int _i = 0;
    
    private int Timer = CountDown.CountDownTimer;

    public void Start()
    {
        CountDown.CountDownTimer = 3;
        _i = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.LogFormat($"OK, we're on the {other.gameObject.name} collider. i={_i}");

        if (other.gameObject.name != checkpoints[_i].name)
            return;
        
        _i++;
        SoloScript.IApassedCheckpoint = _i;

        if (_i >= checkpoints.Length)
        {
            Debug.LogFormat("You Won !!!");
            PortCheckpointIA.IAWin = true;
        }
            
        
    }
    
    void Update()
    {
        Timer = CountDown.CountDownTimer;
        if (Timer == 0)
        {
            // if (_i < checkpoints.Length)
            agent.SetDestination(checkpoints[_i].transform.position);
            /*Debug.LogFormat(
                $"Collider = {_i} ({checkpoints[_i].name}), center = ({checkpoints[_i].transform.position.x}, " +
                $"{checkpoints[_i].transform.position.x}, {checkpoints[_i].transform.position.x})");*/
        }
    }
}