using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

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
    public UnityEvent OnExplode;
    public AudioSource AudioSource;
    public ParticleSystem ParticleSystem;
    public Explosion Explosion;

    public virtual void Start()
    {
        FuseTimer = new Timer(FuseDuration);

        exploder = new Exploder(Damage, Radius, transform, DamageTargets, ExplosionSound, AudioSource, Explosion);
    }
    public void TimerCheck()
    {
        FuseTimer.Update();
        if (FuseTimer.IsComplete && !exploder.IsExploded)
        {
            exploder.Explode();
            OnExplode.Invoke();
        }
    }

    public void StartFuse()
    {
        FuseTimer.Start();

        ExecuteFuseEffects();

    }
        
    public void Stop()
    {
        FuseTimer.Stop();
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
            AudioSource.PlayClipAtPoint(FuseSound, transform.position);
        }
        else
        {
            Debug.LogError("There is no Audio Source attached, but FuseExploder tried to play Fuse Sound");
        }
    }
}
