using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP { private set; get; }

    public int HPRegen;
    public bool IsHealing { private set; get; }
    private bool IsDead;
    
    public int RegenInterval;
    private float HealTimer;
    
    public int RegenDelay;
    private float DamageTimer;

    private bool RecentlyDamaged;

    public UnityEvent DeathEvent;
  
    // Start is called before the first frame update
    public void Start()
    {
        IsDead = false;
        RecentlyDamaged = false;
        CurrentHP = MaxHP;
        IsHealing = false;
    }

    // Update is called once per frame
    public void Update()
    {
        RegenerationTick();
    }
    public void RegenerationTick()
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

        if (CurrentHP <= 0 && !IsDead)
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

    public void Die()
    {
        IsDead = true;
        DeathEvent.Invoke();
    }

    public virtual void EndHealing()
    {
        IsHealing = false;
        HealTimer = 0.0f;
    }
    public virtual void BeginHeal()
    {
        IsHealing = true;
        HealTimer = 0.0f;
    }

    public virtual void HealingStep()
    {
        CurrentHP = Mathf.Clamp(CurrentHP + HPRegen, 0, MaxHP);
        HealTimer = 0.0f;
    }

    public virtual void TakeDamage(int amount)
    {
        CurrentHP -= amount;
        DamageTimer = 0.0f;
        RecentlyDamaged = true;
        EndHealing();
    }
}
