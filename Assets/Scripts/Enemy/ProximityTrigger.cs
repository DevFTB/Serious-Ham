using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : Trigger
{
    public float TriggerDistance;
    public Transform Target;

    private float DistanceToTarget;

    public override bool IsTriggered()
    {
        DistanceToTarget = Vector3.Distance(transform.position, Target.position);
        return DistanceToTarget < TriggerDistance;
    }
}
