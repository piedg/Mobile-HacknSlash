using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastSkillState : PlayerBaseState
{
   

    public PlayerCastSkillState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        GameObject _skillInstance = stateMachine.SpawnGameObject(stateMachine.FireIncendiaryPrefab, stateMachine.SkillPoint.transform);
        stateMachine.DestroyGameObject(_skillInstance, 1.3f);
    }

    public override void Exit() { }

    public override void Tick(float deltaTime)
    {
        Move(Vector2.zero, 0f);

        stateMachine.SwitchState(new PlayerMovementState(stateMachine));
    }
}
