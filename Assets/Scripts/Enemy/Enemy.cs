using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public AudioClip ScreamClip;

    private Transform Target;

    private Follow Follow;
    
    private TriggerFuseExploder TFE;
    private ProximityTrigger Trigger;

    private AudioSource AudioSource;
    private Health Health;
    private GameObject Player;

    public UnityEvent EnemyDeathEvent;
    private bool IsDying;

    public void Start()
    {
        Health = GetComponent<Health>();
        Follow = GetComponent<Follow>();

        TFE = GetComponent<TriggerFuseExploder>();
        Trigger = GetComponent<ProximityTrigger>();

        AudioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");

        SetTarget(Player.transform);
        EnemyDeathEvent.AddListener(Player.GetComponent<PlayerController>().Kill);

        AudioSource.clip = ScreamClip;
    }

    public void Update()
    {
        if (!AudioSource.isPlaying && IsDying)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyDeathEvent.Invoke();
        gameObject.SetActive(false);
    }

    public void SetTarget(Transform target)
    {
        Target = target;

        Follow.Target = Target;
        Trigger.Target = Target;
        TFE.SetDamageTarget(Target.gameObject);
    }

    public void BeginDeath() {
        IsDying = true;

        Follow.enabled = false;
        TFE.enabled = false;

        Scream();
    }

    private void Scream()
    {
        AudioSource.PlayClipAtPoint(ScreamClip, transform.position);
    }

}
