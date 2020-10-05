using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ExploderEnemy : Enemy
{

    private Transform Target;

    private TankFollow Follow;
    
    private TriggerFuseExploder TFE;
    private ProximityTrigger Trigger;

    private ParticleSystem ParticleSystem;


    public void Start()
    {
        base.Start();

        Follow = GetComponent<TankFollow>();

        TFE = GetComponent<TriggerFuseExploder>();
        Trigger = GetComponent<ProximityTrigger>();

        ParticleSystem = GetComponent<ParticleSystem>();

        SetTarget(Player.transform);

    }

    public void Update()
    {
        if (!ParticleSystem.isPlaying)
        {
            base.CheckDeath();
        }

    }

    public void SetTarget(Transform target)
    {
        Target = target;

        Follow.Target = Target;
        Trigger.Target = Target;
        TFE.SetDamageTarget(Target.gameObject);
    }

    public override void BeginDeath() {
        TFE.enabled = false;
        Follow.enabled = false;
        base.BeginDeath();
    }

}
