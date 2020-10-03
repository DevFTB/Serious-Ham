using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHP;
    private int CurrentHP;

    public int HPRegen;
    private bool IsHealing;
    
    public int RegenInterval;
    private float HealTimer;
    
    public int RegenDelay;
    private float DamageTimer;

    private bool RecentlyDamaged;

    public UnityEvent DeathEvent;
  
    // Start is called before the first frame update
    public void Start()
    {
        RecentlyDamaged = false;
        CurrentHP = MaxHP;
        IsHealing = false;
    }

    // Update is called once per frame
    public void Update()
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

        if (CurrentHP <= 0)
        {
            Die();
        } 
        else if (CurrentHP < MaxHP)
        {
            if (!IsHealing && !RecentlyDamaged)
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
        else if (IsHealing)
        {
            EndHealing();
        }

       
    }

    void Die()
    {
        DeathEvent.Invoke();
    }

    void EndHealing()
    {
        IsHealing = false;
        HealTimer = 0.0f;
    }
    void BeginHeal()
    {
        IsHealing = true;
        HealTimer = 0.0f;
    }

    void HealingStep()
    {
        CurrentHP = Mathf.Clamp(CurrentHP + HPRegen, 0, MaxHP);
        HealTimer = 0.0f;
    }

    public void TakeDamage(int amount)
    {
        CurrentHP -= amount;
        DamageTimer = 0.0f;
        RecentlyDamaged = true;
        EndHealing();
    }
}
