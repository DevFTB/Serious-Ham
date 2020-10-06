using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class RollingKill : MonoBehaviour
{
    public int RollDamage;

    private void OnTriggerEnter(Collider other)
    {
        var OtherHealth = other.gameObject.GetComponent<Health>();
        if (OtherHealth && OtherHealth.IsRollable) 
        {
            OtherHealth.TakeDamage(RollDamage);
        }
    }
}
