using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float CrossFadeduration = 0.1f;
    private const float AnimatorDumpTime = 0.1f;

    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeduration);
    }

    public override void Tick(float deltaTime)
    {
        if (IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
            return;
        }

        MoveToPlayer(deltaTime);
        FaceToPlayer();

        stateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDumpTime, deltaTime);
    }

    public override void Exit() { }

    private void MoveToPlayer(float deltaTime)
    {
        if (stateMachine.Player.GetComponent<Health>().IsDead)
        {
            stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDumpTime, deltaTime);
            stateMachine.Rigidbody.velocity = Vector2.zero;
            return;
        }

        Vector2 direction = stateMachine.Player.transform.position - stateMachine.transform.position;
        direction.Normalize();

        stateMachine.Rigidbody.MovePosition((Vector2)stateMachine.transform.position + (direction * stateMachine.MovementSpeed * deltaTime));
    }

    private bool IsInAttackRange()
    {
        if (stateMachine.Player.GetComponent<Health>().IsDead) { return false; }

        stateMachine.Rigidbody.isKinematic = true;
        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }

}
