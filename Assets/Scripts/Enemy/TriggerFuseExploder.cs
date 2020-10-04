using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ProximityTrigger))]
public class TriggerFuseExploder : FuseExploder
{

    private ProximityTrigger Trigger;

    public override void Start()
    {
        base.Start();
        Trigger = GetComponent<ProximityTrigger>();

    }

    public new void Update()
    {
        if (!isBurning)
        {
            if (Trigger.IsTriggered())
            {
                StartFuse();
            }
        }
        else
        {
            if (!Trigger.IsTriggered())
            {
                ResetFuse();
            }

        }

        TimerCheck();
    }
}

