using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private readonly int DeadHash = Animator.StringToHash("Dead");

    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() {
        stateMachine.Animator.SetBool(DeadHash, true);
        GameObject.Destroy(stateMachine.gameObject, 2f);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.Rigidbody.velocity = Vector2.zero;
    }

    public override void Exit() { }
}
