using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ProximityTrigger))]
public class TriggerFuseExploder : FuseExploder
{
    public UnityEvent OnExplode;

    private ProximityTrigger Trigger;

    public override void Start()
    {
        base.Start();
        Trigger = GetComponent<ProximityTrigger>();
    }

    public override void Update()
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

        base.Update();
    }
}

