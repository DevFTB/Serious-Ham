using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 Velocity;
    private int Damage;
    private float Timer;
    private float Lifetime;
    public float MaxDistance;
    private bool Timing;
    // Start is called before the first frame update
    void Start()
    {
        Timing = false;
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timing)
        {
            if (Timer < Lifetime)
            {
                Timer += Time.deltaTime;
            }
            else
            {
                Destroy();
            }
        }

        transform.position += Velocity * Time.deltaTime;
    }

    public void Shoot(Vector3 VelocityVector, int BulletDamage)
    {
        Velocity = VelocityVector;
        Damage = BulletDamage;
        Lifetime = MaxDistance / Velocity.magnitude;
        Timing = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(Damage);
        }
        Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);

    }
}
