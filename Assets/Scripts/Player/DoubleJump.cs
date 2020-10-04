using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Ability
{
    public Movement Movement;
    public KeyCode Key = KeyCode.Space;
    private bool DidDoubleJump;
    public override bool GetAvailable()
    {
        return (!Movement.IsGrounded() && base.GetAvailable() && !DidDoubleJump);
    }
    // Start is called before the first frame update
    void Start()
    {
        DidDoubleJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        TickCooldown();
        if (Input.GetKeyDown(Key) && GetAvailable())
        {
            DoDoubleJump();
        }
        if (DidDoubleJump && Movement.IsGrounded())
        {
            DidDoubleJump = false;
        }
    }

    private void DoDoubleJump()
    {
        base.UseAbility();
        DidDoubleJump = true;
        Movement.Jump();

        UseAbility();
    }
}
