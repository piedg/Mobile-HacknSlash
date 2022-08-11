using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector2 direction, float speed)
    {
        stateMachine.Rigidbody2d.velocity = direction * speed;
    }

    protected void FlipSprite(float directionX)
    {
        if (directionX > 0)
        {
            stateMachine.HealthBar.gameObject.transform.localScale = Vector2.one;
            stateMachine.transform.localScale = Vector2.one;
        }
        else if (directionX < 0)
        {
            stateMachine.HealthBar.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            stateMachine.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}