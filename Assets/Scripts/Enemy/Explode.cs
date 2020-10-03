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
    public GameObject Player;
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
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if (triggered)
        {
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
        float dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist <= AOE)
        {
            Player.GetComponent<Health>().TakeDamage(Damage);
        }
        GetComponent<ParticleSystem>().Play();
    }
}

