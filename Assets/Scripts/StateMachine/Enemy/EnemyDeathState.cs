using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private readonly int DeadHash = Animator.StringToHash("Dead");

    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() {
        GameManager.Instance.KillCount++;
        stateMachine.GetComponent<CapsuleCollider2D>().enabled = false;
        stateMachine.Animator.CrossFadeInFixedTime(DeadHash, 0.1f);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.StartCoroutine(DisableCorotuine());

        stateMachine.Rigidbody.velocity = Vector2.zero;
    }

    public override void Exit() { }

    IEnumerator DisableCorotuine()
    {
        yield return new WaitForSeconds(2f);
        stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        stateMachine.GetComponent<CapsuleCollider2D>().enabled = true;
        stateMachine.gameObject.SetActive(false);
        stateMachine.GetComponent<Health>().SetMaxHealth();
    }
}
