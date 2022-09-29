using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHurtingState : EnemyBaseState
{
    private readonly int ImpactHash = Animator.StringToHash("Hurt");

    private float duration = 0.25f;

    public EnemyHurtingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(ImpactHash, 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.Rigidbody.velocity = Vector3.zero;

        duration -= deltaTime;

        if (duration <= 0)
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }
    }

    public override void Exit() { }

  
}
