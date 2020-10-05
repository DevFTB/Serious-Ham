using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TankEnemy : Enemy
{
    public TankFollow TankFollow;

    public Transform Target;
    public GameObject shell;
    public float HoriSpeed;
    public int ShellDamage;
    public float ShellRadius;
    public float Gravity;
    public AudioClip ShootSound;
    public float MaxRandRange;
    public Explosion Explosion;
    public AudioClip ExplosionSound;
    public List<MeshRenderer> Meshes;
    public override void Start()
    {
        base.Start();

        TankFollow = GetComponent<TankFollow>();
        SetTarget(Player.transform);

    }

    private void Update() {
        CheckDeath();
        if (TankFollow.OutsideOfMinimumSeperation())
        {
            Quaternion direction = Quaternion.LookRotation(Target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        Target = target;

        TankFollow.Target = Target;
    }

    public void Shoot()
    {

        Vector3 StartOffset = new Vector3(0, 2, 0);

        float XRand = Random.Range(-MaxRandRange, MaxRandRange);
        float ZRand = Random.Range(-MaxRandRange, MaxRandRange);
        Vector3 EndOffset = new Vector3(XRand, 0, ZRand);

        Vector3 StartPos = transform.position + StartOffset;
        Vector3 TargetPos = Target.transform.position + EndOffset;
        Vector3 ToTarget = new Vector3(TargetPos.x - StartPos.x, 0, TargetPos.z - StartPos.z);
        float Dist = ToTarget.magnitude;

        float VertSpeed = ((TargetPos.y - StartPos.y) * HoriSpeed / Dist) - (0.5f * -Gravity * (Dist / HoriSpeed));

        Vector3 Velocity = ToTarget.normalized * HoriSpeed + Vector3.up * VertSpeed;
        
        List<GameObject> DamageTargets = new List<GameObject> { Target.gameObject };

        AudioSource.PlayClipAtPoint(ShootSound, StartPos);

        GameObject ShotShell = Instantiate(shell, StartPos, Quaternion.identity);
        ShotShell.GetComponent<Shell>().Shoot(Velocity, ShellDamage, ShellRadius, Gravity, DamageTargets);
        // GameObject ShotBullet = Instantiate(bullet, Gun.transform.position, transform.rotation);
        // ShotBullet.GetComponent<Bullet>().Shoot((transform.forward + Rand) * BulletSpeed, BulletDamage); 
    }

    public override void BeginDeath()
    {
        base.BeginDeath();

    }

    public override void Die()
    {
        Exploder exploder = new Exploder(0, ShellRadius, transform, new List<GameObject>(), ExplosionSound, AudioSource, Explosion);
        GetComponent<Collider>().enabled = false;
        foreach (MeshRenderer mesh in Meshes)
        {
            mesh.enabled = false;
        }
        exploder.Explode();
        Destroy(gameObject, Explosion.Duration);

    }
}
