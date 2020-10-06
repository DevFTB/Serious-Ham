using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TankFollow : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Agent;
    public float AggroRange;

    public float MinimumSeparation;

    public void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        float dist = Vector3.Distance(transform.position, Target.position);

        if (Vector3.Distance(transform.position, Target.transform.position) < AggroRange)
        {
            Agent.isStopped = false;
        }
        else
        {
            Agent.isStopped = true;
        }

        if (OutsideOfMinimumSeperation())
        {
            Quaternion direction = Quaternion.LookRotation(Target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime);
        }
        else
        {
            Vector3 Destination = ((transform.position - Target.position).normalized * (MinimumSeparation - dist)) + transform.position;

            Agent.SetDestination(Destination);

        }
    }

    public bool OutsideOfMinimumSeperation()
    {
        float dist = Vector3.Distance(transform.position, Target.position);
        return (dist > MinimumSeparation);
    }
}
