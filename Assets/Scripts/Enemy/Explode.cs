using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private float ExplodeTimer;
    public float ExplodeTime;
    public int Damage;
    public float AOE;
    public float TriggerDistance;
    public float StopDistance;
    public Transform Player;
    private bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        ExplodeTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.position, transform.position);
        if (triggered)
        {
            Debug.Log("Exploding");
            if (dist < StopDistance)
            {
                ExplodeTimer += Time.deltaTime;
                if (ExplodeTimer >= ExplodeTime)
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
        triggered = true;
    }

    void StopExplosion()
    {
        triggered = false;
        ExplodeTimer = 0.0f;
    }

    void DoExplosion()
    {
        Debug.Log("Boom");
        float dist = Vector3.Distance(Player.position, transform.position);

        if (dist <= AOE)
        {
            Player.GetComponent<Health>().TakeDamage(Damage);
        }
        GetComponent<ParticleSystem>().Play();
    }
}

