using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float Cooldown;
    private float CooldownTimer;
    public bool IsCooledDown { get; private set; }
    private bool IsCoolingDown;
    // Start is called before the first frame update
    public void Start()
    {
        CooldownTimer = 0.0f;
        IsCooledDown = true;
        IsCoolingDown = false;
    }

    // Update is called once per frame
    public void TickCooldown()
    {
        if (!IsCooledDown)
        {
            if (!IsCoolingDown)
            {
                BeginCooldown();
            }
            else
            {
                if (CooldownTimer < Cooldown)
                {
                    CooldownTimer += Time.deltaTime;
                }
                else
                {
                    EndCooldown();
                }
            }

        }
    }

    public void BeginCooldown()
    {
        IsCoolingDown = true;
        CooldownTimer = 0.0f;
    }

    public void EndCooldown()
    {
        IsCoolingDown = false;
        CooldownTimer = 0.0f;
        IsCooledDown = true;
    }

    public float GetCooldown()
    {
        return Cooldown / CooldownTimer;
    }


    public virtual bool GetAvailable()
    {
        return IsCooledDown;
    }

    public void UseAbility() 
    {
        IsCooledDown = false;
    }

}
