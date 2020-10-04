using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public AudioClip ScreamClip;

    private Transform Target;

    private Follow Follow;
    private ProximityExploder Pe;
    private AudioSource AudioSource;
    private Health Health;
    private GameObject Player;

    public UnityEvent EnemyDeathEvent;
    private bool isDying;

    public void Start()
    {
        Health = GetComponent<Health>();
        Follow = GetComponent<Follow>();

        Pe = GetComponent<ProximityExploder>();
        AudioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");

        SetTarget(Player.transform);
        EnemyDeathEvent.AddListener(Player.GetComponent<PlayerController>().Kill);

        

        AudioSource.clip = ScreamClip;
    }

    public void Update()
    {
        if(!AudioSource.isPlaying && isDying)
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
        Pe.Target = Target;
    }

    public void BeginDeath() {
        isDying = true;
        Scream();


        //gameObject.SetActive(false);
    }

    public void Scream()
    {
        AudioSource.Play();
    }

}
