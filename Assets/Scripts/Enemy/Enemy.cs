using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip ScreamClip;

    private Transform Target;

    private Follow Follow;
    
    private TriggerFuseExploder TFE;
    private ProximityTrigger Trigger;

    private AudioSource AudioSource;
    private Health Health;

    private bool isDying;

    public void Start()
    {
        Health = GetComponent<Health>();
        Follow = GetComponent<Follow>();

        TFE = GetComponent<TriggerFuseExploder>();
        Trigger = GetComponent<ProximityTrigger>();

        AudioSource = GetComponent<AudioSource>();

        SetTarget(GameObject.FindGameObjectWithTag("Player").transform);

        AudioSource.clip = ScreamClip;
    }

    public void Update()
    {
        if (!AudioSource.isPlaying && isDying)
        {
            Die();
        }
    }

    private void Die()
    {
        //gameObject.SetActive(false);
    }

    public void SetTarget(Transform target)
    {
        Target = target;

        Follow.Target = Target;
        Trigger.Target = Target;
        TFE.SetDamageTarget(Target.gameObject);
    }

    public void BeginDeath() {
        isDying = true;

        TFE.enabled = false;

        Scream();
    }

    private void Scream()
    {
        AudioSource.PlayOneShot(ScreamClip);
    }
}
