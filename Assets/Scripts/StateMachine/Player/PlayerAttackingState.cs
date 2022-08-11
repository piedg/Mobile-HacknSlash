using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float previousFrameTime;

    Vector2 direction;

    public PlayerAttackingState(PlayerStateMachine stateMachine, Vector2 _direction) : base(stateMachine) {
        direction = _direction;
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime("Attack", 0.1f);
    }

    public override void Exit() { }

    public override void Tick(float deltaTime)
    {
        Move(direction, 0f);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            //Debug.Log("Try Combo");
        }
        else
        {
            stateMachine.SwitchState(new PlayerMovementState(stateMachine));
        }
        previousFrameTime = normalizedTime;
    }
}
