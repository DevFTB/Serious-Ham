using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    public float ForwardAcceleration;
    public float SidewaysTorque;

    public float MaximumSpeed;

    public float MaxiumZRotation;

    private Rigidbody rb;
    private bool OnGround;
    public float CorrectionFactor;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        rb.AddRelativeTorque(Vector3.up * SidewaysTorque * horizontal, ForceMode.Acceleration);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
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
