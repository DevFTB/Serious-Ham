using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Anim;

    public float MaximumSpeedForIdle;

    private bool JumpedYet = false;
    private Movement Movement;

    public void Start()
    {
        Movement = GetComponent<Movement>();
    }

    public void Update()
    {

        bool IsIdle = Mathf.Abs(Movement.GetVelocity().z) < MaximumSpeedForIdle;
        bool MovingForward = Movement.GetVelocity().z > 0;

        Anim.SetBool("MovingForward", MovingForward);


        Anim.SetBool("IsIdle", IsIdle);
        
        if(!JumpedYet && Movement.Jumped)
        {
            Anim.SetTrigger("Jump");
             
        }

        if(JumpedYet && !Movement.Jumped)
        {
            JumpedYet = false;
        }

        Anim.SetBool("OnGround", Movement.IsGrounded());

    }
}
