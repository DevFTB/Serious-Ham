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

    public float SlamAcceleration;
    private bool isSlamming;

    public float Gravity;
    public float JumpSpeed;
    public float TurnSpeed;

    private CharacterController cc;
    private Vector3 Velocity; 
    
    // Start is called before the first frame update
    void Start()
    {
        isSlamming = false;

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


        Velocity.z = Mathf.Clamp(Velocity.z, -MaximumSpeed, MaximumSpeed);

        if (cc.isGrounded)
        {
            if (isSlamming) isSlamming = false;
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Slam();
            }

            if (isSlamming)
            {
                Velocity.y -= SlamAcceleration * Time.deltaTime;
            }
            Velocity.y -= Gravity * Time.deltaTime;
        }


        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.Rotate(new Vector3(0, horizontal * TurnSpeed * Time.deltaTime, 0));

        

        cc.Move(transform.rotation * Velocity * Time.deltaTime);
    }

    private void Slam()
    {
        isSlamming = true;
    }

    private void Jump()
    {
        Velocity.y += JumpSpeed;
    }
}
