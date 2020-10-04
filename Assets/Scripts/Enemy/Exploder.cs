using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    private Transform ExploderTransform;
    private List<GameObject> DamageTargets;

    private int Damage;
    private float Radius;

    private AudioSource AudioSource;
    private AudioClip ExplosionSound;

    private ParticleSystem PS;
    public bool IsExploded { get; private set; }

    public Exploder(int damage, float radius, Transform exploderTransform, List<GameObject> damageTargets, AudioClip explosionSound = null, AudioSource audioSource = null, ParticleSystem ps = null)
    {
        Damage = damage;
        Radius = radius;
        ExploderTransform = exploderTransform;
        DamageTargets = damageTargets;

        AudioSource = audioSource;
        ExplosionSound = explosionSound;
        PS = ps;
    }

    public Exploder(int damage, float radius, GameObject exploderWithEffects, List<GameObject> damageTargets, AudioClip explosionSound)
    {
        Damage = damage;
        Radius = radius;
        ExploderTransform = exploderWithEffects.transform;
        DamageTargets = damageTargets;

        AudioSource = exploderWithEffects.GetComponent<AudioSource>();
        ExplosionSound = explosionSound;
        PS = exploderWithEffects.GetComponent<ParticleSystem>();
    }

    public void Explode()
    {
        ExecuteExplosionEffects();

        IsExploded = true;

        foreach (GameObject Target in DamageTargets)
        {
            float dist = Vector3.Distance(Target.transform.position, ExploderTransform.position);
            if (dist <= Radius)
            {

                Target.GetComponent<Health>().TakeDamage(Damage);
            }

        }
    }

    private void ExecuteExplosionEffects()
    {
        if (ExplosionSound)
        {
            if (AudioSource)
            {
                AudioSource.PlayClipAtPoint(ExplosionSound, ExploderTransform.position);
                // Debug.Log("BOOM TIME");

            }
            else
            {
                Debug.LogError("There is no Audio Source attached, but Exploder tried to play Explosion Sound");
            }
        }

        if (PS)
        {
            PS.Play();
        }
    }
}
