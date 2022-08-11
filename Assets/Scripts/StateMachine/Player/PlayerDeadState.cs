using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private readonly int DeadHash = Animator.StringToHash("Dead");
    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(DeadHash, 0.1f);
    }

    public override void Exit() { }

    public override void Tick(float deltaTime)
    {
        Move(Vector2.zero, 0f);
    }
}
