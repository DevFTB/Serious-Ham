using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollExplosion : MonoBehaviour
{
    public GameObject Ragdoll;
    
    public void Kaboom()
    {
        GameObject GO = Instantiate(Ragdoll, transform.position, transform.rotation);
    }
}
