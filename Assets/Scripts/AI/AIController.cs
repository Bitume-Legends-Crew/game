using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{ 
    public BoxCollider[] checkpoints;
    public NavMeshAgent agent;
    private int _i = 0;
    void Update()
    {
        // if (_i < checkpoints.Length)
        agent.SetDestination(checkpoints[_i].center);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != checkpoints[_i].name)
            return;
        
        Debug.LogFormat($"OK, we're on the {other.gameObject.name} collider. i={_i}");
        agent.SetDestination(checkpoints[_i + 1].center);
        _i++;
    }
}
