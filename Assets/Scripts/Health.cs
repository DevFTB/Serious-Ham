using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHP;
    private int CurrHP;
    public int HPRegen;
    private bool Healing;
    public int RegenInterval;
    private float HealTimer;
    public int RegenDelay;
    private float DamageTimer;
    private bool RecentlyDamaged;
  
    // Start is called before the first frame update
    void Start()
    {
        RecentlyDamaged = false;
        CurrHP = MaxHP;
        Healing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RecentlyDamaged)
        {
            if (DamageTimer < RegenDelay)
            {
                DamageTimer += Time.deltaTime;
            }
            else
            {
                RecentlyDamaged = false;
                DamageTimer = 0.0f;
            }
        }
        else
        {
            DamageTimer = 0.0f;
        }

        if (CurrHP <= 0)
        {
            Die();
        } 
        else if (CurrHP < MaxHP)
        {
            if (!Healing && !RecentlyDamaged)
            {
                BeginHeal();
            }
            else
            {
                if (HealTimer < RegenInterval)
                {
                    HealTimer += Time.deltaTime;
                }
                else
                {
                    HealingStep();
                }
            }
        }
        else if (Healing)
        {
            EndHealing();
        }

       
    }

    void Die()
    {
       
    }

    void EndHealing()
    {
        Healing = false;
        HealTimer = 0.0f;
    }
    void BeginHeal()
    {
        Healing = true;
        HealTimer = 0.0f;
    }

    void HealingStep()
    {
        if (CurrHP < MaxHP)
        {
            CurrHP += HPRegen;
        }
        CurrHP = Mathf.Clamp(CurrHP, 0, MaxHP);
        HealTimer = 0.0f;
    }

    public void TakeDamage(int amount)
    {
        CurrHP -= amount;
        DamageTimer = 0.0f;
        RecentlyDamaged = true;
        EndHealing();
    }
}
