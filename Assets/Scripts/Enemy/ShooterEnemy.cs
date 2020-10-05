using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class ShooterEnemy : Enemy
{
    public GameObject bullet;
    public float BulletSpeed;
    public int BulletDamage;
    public GameObject Gun;
    private TankFollow Follow;
    private Transform Target;
    public float SpreadFactor;
    public float ShootRange;



    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        Follow = GetComponent<TankFollow>();
        SetTarget(Player.transform);

    }

    public bool GetInRange()
    {
        return (Vector3.Distance(Player.transform.position, transform.position) < ShootRange);
    }
    private void Update()
    {
        if (GetInRange())
        {
            transform.LookAt(Player.transform);

        }


        base.CheckDeath();

    }
    public void SetTarget(Transform target)
    {
        Target = target;

        Follow.Target = Target;
    }

    // Update is called once per frame

    public void Shoot()
    {
        float RandX = Random.Range(-SpreadFactor, SpreadFactor);
        float RandY = Random.Range(-SpreadFactor, SpreadFactor);
        float RandZ = Random.Range(-SpreadFactor, SpreadFactor);
        Vector3 Rand = new Vector3(RandX, RandY, RandZ);
        GameObject ShotBullet = Instantiate(bullet, Gun.transform.position, transform.rotation);
        ShotBullet.GetComponent<Bullet>().Shoot((transform.forward + Rand) * BulletSpeed, BulletDamage); 
    }
}
 