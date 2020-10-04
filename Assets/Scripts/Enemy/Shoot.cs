using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Ability
{
    public float AttacksPerMinute;
    public ShooterEnemy ShooterEnemy;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        Cooldown = 60f / AttacksPerMinute;
    }

    // Update is called once per frame
    void Update()
    {
        base.TickCooldown();
        if (GetAvailable())
        {
            ShooterEnemy.Shoot();
            UseAbility();
        }
    }

    public override bool GetAvailable()
    {
        return (base.GetAvailable() && ShooterEnemy.GetInRange());
    }
}
