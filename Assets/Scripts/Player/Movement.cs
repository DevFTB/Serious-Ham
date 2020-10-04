using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Acceleration;
    public float Friction;
    public float BrakingAcceleration;
    public float MaximumSpeed;

    private bool IsClamped;
    public float AirMovementDampeningFactor;

    public float Gravity;
    public float JumpSpeed;
    public float TurnSpeed;

    public float SlopeAccelFactor;


    private CharacterController cc;
    private Vector3 Velocity; 
    
    // Start is called before the first frame update
    void Start()
    {
        IsClamped = true;
        Velocity = new Vector3();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Velocity.y);
        // Debug.Log(FindSurfaceSlope());
        if (Input.GetKey(KeyCode.W))
        {
            Velocity.z += Acceleration * Time.deltaTime;

        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                Velocity.z -= BrakingAcceleration * Time.deltaTime;
            }
            
        }

        if (cc.isGrounded)
        {
            //slope acceleration
            // Debug.Log(SlopeAccelFactor * Gravity * Mathf.Sin(Mathf.Deg2Rad * FindSurfaceSlope()));
            Velocity.z -= SlopeAccelFactor * Gravity * Mathf.Sin(Mathf.Deg2Rad * FindSurfaceSlope());
            if (Input.GetKey(KeyCode.Space))
            {
                Velocity.y = 0;
                Jump();
            }
        }
                
        Velocity.z -= Mathf.Sign(Velocity.z) * Friction * Time.deltaTime;

        if (IsClamped)
        {
            Velocity.z = Mathf.Clamp(Velocity.z, -MaximumSpeed, MaximumSpeed);

        }

        else
        {
            if (IsClamped)
            {
                Velocity.z *= AirMovementDampeningFactor;
            }
        }

        Velocity.y -= Gravity * Time.deltaTime;


        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.Rotate(new Vector3(0, horizontal * TurnSpeed * Time.deltaTime, 0));

        cc.Move(transform.rotation * Velocity * Time.deltaTime);



    }

    public void Clamp()
    {
        IsClamped = true;
    }

    public void UnClamp()
    {
        IsClamped = false;
    }

    public Vector3 GetMovementDirection()
    {
        return Velocity.normalized;
    }

    public Vector3 GetForwardVector()
    {
        return -Vector3.Cross(Vector3.up, transform.right);
    }

    public Vector3 GetVelocity()
    {
        return Velocity;
    }

    public void AddVelocity(Vector3 AddedVelocity, bool clamped = true)
    {
        Velocity += AddedVelocity;
        IsClamped = clamped;
        
    }

    public void AddRelativeVelocity(Vector3 AddedVelocity, bool clamped = true)
    {
        Velocity += transform.rotation * AddedVelocity;
        IsClamped = clamped;
    }

    public void Jump()
    {
        Velocity.y += JumpSpeed;
    }

    public bool IsGrounded()
    {
        return cc.isGrounded;
    }
    
     float FindSurfaceSlope()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit)) 
        {
            Vector3 SurfNormal = hit.normal;
            Vector3 Forward = GetForwardVector();
            return (Vector3.Angle(SurfNormal, Forward) - 90);
        }
        else
        {
            return 0;
        }
    }
}
