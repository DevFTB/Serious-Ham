using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

public class ProximityExploder : MonoBehaviour
{
    private float ExplodeTimer;
    public float ExplodeGracePeriod;

    public int Damage;
    public float Radius;
    
    public float TriggerDistance;
    public float CancelDistance;

    public Transform Target;
    private bool Triggered;

    public UnityEvent OnExplode;
    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
        ExplodeTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Target.position, transform.position);
        if (Triggered)
        {
            if (dist < CancelDistance)
            {
                ExplodeTimer += Time.deltaTime;
                if (ExplodeTimer >= ExplodeGracePeriod)
                {
                    DoExplosion();
                    StopExplosion();
                }
            }
            else
            {
                StopExplosion();
            }
        }
        else if (dist < TriggerDistance)
        {
            TriggerExplosion();
        }
    }

    void TriggerExplosion()
    {
        Triggered = true;
    }

    void StopExplosion()
    {
        Triggered = false;
        ExplodeTimer = 0.0f;
    }

    void DoExplosion()
    {
        float dist = Vector3.Distance(Target.position, transform.position);

        if (dist <= Radius)
        {
            Target.GetComponent<Health>().TakeDamage(Damage);
        }

        ParticleSystem Ps = GetComponent<ParticleSystem>();
        if (Ps)
        {
            Ps.Play();
        }

        OnExplode.Invoke();
    }
}

