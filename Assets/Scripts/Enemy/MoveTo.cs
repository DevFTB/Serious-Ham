using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Vector3 TargetPosition;
    private NavMeshAgent Agent;
    public int WalkableIndex;
    public int WalkableCost;
    public int JumpIndex;
    public int JumpCost;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetAreaCost(JumpIndex, JumpCost);
        Agent.SetAreaCost(WalkableIndex, WalkableCost);
    }

    // Update is called once per frame
    void Update()
    {
        Agent.destination = TargetPosition;
    }
}
