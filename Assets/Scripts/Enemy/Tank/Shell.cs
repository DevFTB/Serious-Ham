using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private Vector3 Velocity;
    private int Damage;
    private float Timer;
    private float Lifetime;
    public float MaxTime;
    private bool Timing;

    private float Radius;
    private Exploder exploder;
    public AudioClip ExplosionSound;
    private float ShellGravity;
    private bool IsExploded;

    void Start()
    {
        Timing = false;
        Timer = 0.0f;
        IsExploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsExploded)
        {
            if (Timing)
            {
                if (Timer < Lifetime)
                {
                    Timer += Time.deltaTime;
                }
                else
                {
                    Destroy(0);
                }
            }
            transform.position += Velocity * Time.deltaTime;
            Velocity += new Vector3(0, -ShellGravity, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        exploder.Explode();
        IsExploded = true;
        ParticleSystem particles = GetComponent<ParticleSystem>();
        Destroy(particles.main.duration);
    }

    public void Shoot(Vector3 VelocityVector, int ShellDamage, float ShellRadius, float Gravity, List<GameObject> DamageTargets)
    {
        Velocity = VelocityVector;
        Lifetime = MaxTime;
        exploder = new Exploder(ShellDamage, ShellRadius, gameObject, DamageTargets, ExplosionSound);
        ShellGravity = Gravity;
        Timing = true;
    }

    public void Destroy(float delay)
    {

        Destroy(gameObject, delay);
    }
}
