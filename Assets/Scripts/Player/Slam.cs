using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : Ability
{
    public Movement Movement;
    private bool IsSlamming;
    public float SlamSpeed;
    public KeyCode Key;

    // Start is called before the first frame update
    void Start()
    {
        IsSlamming = false;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.TickCooldown();
        if (Input.GetKeyDown(Key) && GetAvailable())
        {
            StartSlam();
        }
        if (IsSlamming)
        {
            DoSlam();
        }
        if (Movement.IsGrounded())
        {
            EndSlam();
        }
    }

    private void DoSlam()
    {
        Movement.AddVelocity(Vector3.down * SlamSpeed, false);
    }

    private void EndSlam()
    {
        IsSlamming = false;
    }

    private void StartSlam()
    {
        IsSlamming = true;
        base.UseAbility();
    }
}