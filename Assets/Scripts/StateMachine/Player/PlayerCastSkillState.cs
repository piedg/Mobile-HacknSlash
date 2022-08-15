using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastSkillState : PlayerBaseState
{
    float remainingCastTime;

    public PlayerCastSkillState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        remainingCastTime = stateMachine.SpellCastTime;

        GameObject _skillInstance = stateMachine.SpawnGameObject(stateMachine.FireIncendiaryPrefab, stateMachine.SkillPoint.transform);
        stateMachine.DestroyGameObject(_skillInstance, 1.3f);
    }

    public override void Exit() { }

    public override void Tick(float deltaTime)
    {
        Move(Vector2.zero, 0f);

        remainingCastTime -= deltaTime;

        if (remainingCastTime <= 0f)
        {
            stateMachine.SwitchState(new PlayerMovementState(stateMachine));
        }

    }
}
