using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent Agent;
    public float AggroRange = 50;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Agent.destination = Target.position;
        if (Vector3.Distance(transform.position, Target.transform.position) < AggroRange)
        {
            Agent.isStopped = false;
        }
        else
        {
            Agent.isStopped = true;
        }

    }
}
