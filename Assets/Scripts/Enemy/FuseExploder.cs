using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseExploder : MonoBehaviour
{
    public int Damage;
    public float Radius;

    public List<GameObject> DamageTargets;

    public float FuseDuration;

    public AudioClip FuseSound;
    public AudioClip ExplosionSound;

    public bool isBurning { get => FuseTimer.IsActive; }

    private Timer FuseTimer;

    private Exploder exploder;

    public virtual void Start()
    {
        FuseTimer = new Timer(FuseDuration);

        exploder = new Exploder(Damage, Radius, gameObject, DamageTargets, ExplosionSound);
    }
    public void TimerCheck()
    {
        FuseTimer.Update();
        if (FuseTimer.IsComplete && !exploder.IsExploded) exploder.Explode();
    }

    public void StartFuse()
    {
        FuseTimer.Start();

        ExecuteFuseEffects();

    }
        
    public void ResetFuse()
    {
        FuseTimer.Reset();
    }

    internal void SetDamageTarget(GameObject Object)
    {
        DamageTargets.Clear();
        DamageTargets.Add(Object);

        exploder = new Exploder(Damage, Radius, gameObject, DamageTargets, ExplosionSound);
    }

    private void ExecuteFuseEffects()
    {
        AudioSource AudioSource = gameObject.GetComponent<AudioSource>();
        if (AudioSource)
        {
            AudioSource.PlayOneShot(FuseSound);
        }
        else
        {
            Debug.LogError("There is no Audio Source attached, but FuseExploder tried to play Fuse Sound");
        }
    }
}
