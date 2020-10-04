using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : Ability
{
    public float AttacksPerMinute;
    public TankEnemy TankEnemy;
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
            TankEnemy.Shoot();
            UseAbility();
        }
    }
}