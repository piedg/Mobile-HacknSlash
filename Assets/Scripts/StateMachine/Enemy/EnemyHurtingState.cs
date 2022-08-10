using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtingState : EnemyBaseState
{
    private readonly int ImpactHash = Animator.StringToHash("Hurting");

    private float duration = 0.25f;

    public EnemyHurtingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.SetTrigger(ImpactHash);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.Rigidbody.velocity = Vector3.zero;

        duration -= deltaTime;

        if (duration <= 0)
        {
            stateMachine.Animator.ResetTrigger(ImpactHash);
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }
    }

    public override void Exit() { }
}
