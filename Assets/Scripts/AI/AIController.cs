using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{ 
    public BoxCollider[] checkpoints;
    public NavMeshAgent agent;
    private int i = 0;
    void Update()
    {
        if (i < checkpoints.Length)
        {
            agent.SetDestination(checkpoints[i].center);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == checkpoints[i].name)
        {
            Debug.LogFormat($"OK, we're on the {other.gameObject.name} collider. i={i}");
            agent.SetDestination(checkpoints[i + 1].center);
            i++;
        }
    }
}
