using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip ScreamClip;

    private Transform Target;

    private Follow Follow;
    private ProximityExploder Pe;
    private AudioSource AudioSource;
    private Health Health;

    private bool isDying;

    public void Start()
    {
        Health = GetComponent<Health>();
        Follow = GetComponent<Follow>();

        Pe = GetComponent<ProximityExploder>();
        AudioSource = GetComponent<AudioSource>();

        SetTarget(GameObject.FindGameObjectWithTag("Player").transform);

        

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
        gameObject.SetActive(false);
    }

    public void SetTarget(Transform target)
    {
        Debug.Log(target);
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
