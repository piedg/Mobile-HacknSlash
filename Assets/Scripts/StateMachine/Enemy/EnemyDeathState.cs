using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private readonly int DeadHash = Animator.StringToHash("Dead");

    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.Animator.SetTrigger(DeadHash);

        stateMachine.Rigidbody.velocity = Vector2.zero;

        GameObject.Destroy(stateMachine.gameObject, 2.5f);
    }

    public override void Exit() { }
}
