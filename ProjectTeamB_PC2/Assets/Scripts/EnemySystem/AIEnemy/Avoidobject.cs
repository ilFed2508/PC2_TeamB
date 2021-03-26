using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Avoidobject : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform pointTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(pointTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.remainingDistance.ToString());
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Debug.Log("Arrivato");
        }
    }
}
