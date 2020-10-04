using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public GameObject DamageLayer;
    public void UpdateDamageLayer()
    {
        DamageLayer.GetComponent<HealthOverlay>().UpdateHealth((float)(CurrentHP)/MaxHP, IsHealing);
    }
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        RegenerationTick();
    }



    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);

    }
}
