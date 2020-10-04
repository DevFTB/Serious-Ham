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

        Velocity.z -= Mathf.Sign(Velocity.z) * Friction * Time.deltaTime;

        if (IsClamped)
        {
            Velocity.z = Mathf.Clamp(Velocity.z, -MaximumSpeed, MaximumSpeed);

        }

        if (cc.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
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
}
