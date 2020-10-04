using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Dash : Ability
{
    public Movement Movement;
    public float Duration;
    private float DashTimer;
    private bool IsDashing;
    public float DashSpeed;
    public KeyCode Key;

    // Start is called before the first frame update
    void Start()
    {
        DashTimer = 0.0f;
        IsDashing = false;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.TickCooldown();
        if (Input.GetKeyDown(Key) && GetAvailable())
        {
            StartDash();
        }
        if (IsDashing)
        {
            if (DashTimer < Duration)
            {
                DashTimer += Time.deltaTime;
                DoDash();
            }
            else
            {
                EndDash();
            }
        }
    }

    private void DoDash()
    {
        Movement.AddVelocity(new Vector3(0,0,1)  * DashSpeed * Time.deltaTime, false);
    }

    private void EndDash()
    {
        Movement.Clamp();
        IsDashing = false;
        DashTimer = 0.0f;
        base.UseAbility();
    }

    private void StartDash()
    {
        IsDashing = true;
        DashTimer = 0.0f;
    }



}
