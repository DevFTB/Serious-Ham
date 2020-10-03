using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float ExplodeTimer;
    public float ExplodeTime;
    public float Damage;
    public float AOE;
    public float TriggerDistance;
    public float StopDistance;
    public Transform player;
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
        var dist = Vector3.Distance(player.position, transform.position);
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

    }
}
