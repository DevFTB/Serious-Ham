using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    public float ForwardAcceleration;
    public float SidewaysTorque;

    public float MaximumSpeed;
    public float Stability;

    private Rigidbody rb;
    private bool OnGround;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (OnGround)
        {
            rb.AddRelativeTorque(Vector3.right * ForwardAcceleration * vertical, ForceMode.Acceleration);
        }

        Vector3 predictedUp = Quaternion.AngleAxis(
           rb.angularVelocity.magnitude * Mathf.Rad2Deg * Stability,
           rb.angularVelocity
       ) * transform.up;

        Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
        // Uncomment the next line to stabilize on only 1 axis.
        torqueVector = Vector3.Project(torqueVector, transform.forward);
        rb.AddTorque(torqueVector);

        //rb.AddRelativeTorque(Vector3.up * SidewaysTorque * horizontal, ForceMode.Acceleration);

        //float PercentageFallenOver = transform.eulerAngles.z / 90;

        //rb.AddTorque(Vector3.forward * -Mathf.Exp(PercentageFallenOver) * 5);
        //Debug.Log(PercentageFallenOver);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            OnGround = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            OnGround = false;
        }
    }
}
