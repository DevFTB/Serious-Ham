using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TankFollow : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Agent;

    public float MinimumSeparation;

    public void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        float dist = Vector3.Distance(transform.position, Target.position);

        if(dist > MinimumSeparation)
        {
            Agent.SetDestination(Target.position);
            Debug.Log(dist + ", Moving Towards");

        }
        else
        {
            Vector3 Destination = ((transform.position - Target.position).normalized * (MinimumSeparation - dist)) + transform.position;

            Debug.Log(dist + ", Moving Away to " + Destination + " from Current Pos: " + transform.position);
            Agent.SetDestination(Destination);

        }
    }
}
