using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Slam : Ability
{
    public Movement Movement;
    private bool IsSlamming;
    public float SlamSpeed;
    public float SlamForce;
    public float SlamRadius;
    public int SlamDamage;
    public float UpwardsModifier;
    public float MinSlamHeight;
    public float VelocityFactor;
    public KeyCode Key;
    public AudioSource AudioSource;
    public AudioClip SlamStartClip;
    public AudioClip SlamImpactClip;

    // Start is called before the first frame update
    void Start()
    {
        IsSlamming = false;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.TickCooldown();
        if (Input.GetKeyDown(Key) && GetAvailable())
        {
            if (!Movement.IsGrounded()) 
            { 
                StartSlam(); 
            }
            
        }
        if (IsSlamming)
        {
            DoSlam();
            if (Movement.IsGrounded())
            {
                EndSlam();
            }
        }
    }

    private void DoSlam()
    {
        Movement.AddVelocity(Vector3.down * SlamSpeed, false);
    }

    private void EndSlam()
    {
        Movement.Clamp();
        IsSlamming = false;
        AudioSource.PlayOneShot(SlamImpactClip);
        base.UseAbility();
        Collider[] InRadius = Physics.OverlapSphere(transform.position, SlamRadius);
        foreach (var CollisionObject in InRadius)
        {
            var Health = CollisionObject.gameObject.GetComponent<Health>();
            if (Health && Health.IsSlammable)
            {
                CollisionObject.gameObject.GetComponent<Rigidbody>().AddExplosionForce(SlamForce * -Movement.GetVelocity().y * VelocityFactor, transform.position, SlamRadius, UpwardsModifier, ForceMode.Impulse);
                if (CollisionObject.gameObject.GetComponent<Health>())
                {
                    CollisionObject.gameObject.GetComponent<Health>().TakeDamage(SlamDamage);
                }
            }
        }
    }

    private void StartSlam()
    {
        IsSlamming = true;
        AudioSource.PlayOneShot(SlamStartClip);
    }
}