using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void FaceToPlayer()
    {
        if (stateMachine.Player.transform.position.x > stateMachine.transform.position.x)
        {
            stateMachine.transform.localScale = Vector2.one;
        }
        else if(stateMachine.Player.transform.position.x < stateMachine.transform.position.x)
        {
            stateMachine.transform.localScale = new Vector2(-1, 1);
        }
    }

    protected bool IsInChaseRange()
    {
        if (stateMachine.Player.GetComponent<Health>().IsDead) { return false; }

        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;
    }

}
