using UnityEngine;
using UnityEngine.PlayerLoop;

public class ExplodableRagdoll : MonoBehaviour
{    
    public Rigidbody ParentRigidbody;
    public float UpwardsForce;
    public float ExpireTime;
    private Timer ExpireTimer;


    public void Start()
    {
        Vector3 RandomVector = new Vector3(Random.Range(0, 1), 1, Random.Range(0, 1)).normalized;
        ParentRigidbody.AddForce(RandomVector * UpwardsForce, ForceMode.VelocityChange);
        ExpireTimer = new Timer(ExpireTime);
        ExpireTimer.Start();
    }

    public void Update()
    {
        ExpireTimer.Update();
        if (ExpireTimer.IsComplete)
        {
            Destroy(gameObject);
        }
    }
}