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
    private Follow Follow;
    private Transform Target;
    public float SpreadFactor;
    public float ShootRange;
    public AudioClip ShootClip;



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Follow = GetComponent<Follow>();
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
            Quaternion direction = Quaternion.LookRotation(Player.transform.position - Gun.transform.position);
            Gun.transform.rotation = Quaternion.Slerp(Gun.transform.rotation, direction, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime);

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
        Vector3 Direction = Target.transform.position + new Vector3(0, 1, 0) - Gun.transform.position;
        GameObject ShotBullet = Instantiate(bullet, Gun.transform.position, Gun.transform.rotation);
        AudioSource.PlayClipAtPoint(ShootClip, Gun.transform.position);
        ShotBullet.GetComponent<Bullet>().Shoot((Direction + Rand) * BulletSpeed, BulletDamage); 
    }
}
 