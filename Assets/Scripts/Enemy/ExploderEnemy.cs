using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ExploderEnemy : Enemy
{

    private Transform Target;

    private Follow Follow;
    
    private TriggerFuseExploder TFE;
    private ProximityTrigger Trigger;

    private ParticleSystem ParticleSystem;
    public float ExplodeDuration;
    private float TimeSinceDeath;
    public List<MeshRenderer> Meshes;


    public void Start()
    {
        base.Start();

        Follow = GetComponent<Follow>();

        TFE = GetComponent<TriggerFuseExploder>();
        Trigger = GetComponent<ProximityTrigger>();

        ParticleSystem = GetComponent<ParticleSystem>();

        SetTarget(Player.transform);

    }

    public void Update()
    {
        if (IsDying)
        {
            if (TimeSinceDeath > ExplodeDuration)
            {
                base.CheckDeath();
            }
            else
            {
                TimeSinceDeath += Time.deltaTime;
            }
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
        GetComponent<Collider>().enabled = false;
        foreach (MeshRenderer mesh in Meshes)
        {
            mesh.enabled = false;
        }
        TFE.enabled = false;
        Follow.enabled = false;
        TimeSinceDeath = 0.0f;
        base.BeginDeath();

    }

}
