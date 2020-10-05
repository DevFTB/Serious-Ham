using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class CivilianEnemy : Enemy
{
    public List<GameObject> Waypoints;
    private Transform CurrentTarget;

    private MoveTo MoveTo;

    public float WaypointDistance;

    // Start is called before the first frame update
    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
        base.Start();
        MoveTo = GetComponent<MoveTo>();
        SelectNewTarget();
    }

    bool Arrived()
    {
        return (Vector3.Distance(CurrentTarget.transform.position, transform.position) < WaypointDistance);
    }

    // Update is called once per frame
    void Update()
    {
        base.CheckDeath();
        if (Arrived())
        {
            SelectNewTarget();
        }
        
    }

    void SelectNewTarget()
    {
        List<GameObject> TempList = Waypoints.Where(waypoint => waypoint != CurrentTarget).ToList();
        int RandomIndex = Random.Range(0, TempList.Count() - 1);
        CurrentTarget = TempList[RandomIndex].transform;
        MoveTo.Target = CurrentTarget.transform;
    }
}
