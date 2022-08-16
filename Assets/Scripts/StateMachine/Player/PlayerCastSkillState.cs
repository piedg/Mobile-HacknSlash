using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastSkillState : PlayerBaseState
{
    float remainingCastTime;
    Skill currentSkill;

    public PlayerCastSkillState(PlayerStateMachine stateMachine, int skillIndex) : base(stateMachine)
    {
        currentSkill = stateMachine.Skills[skillIndex];
    }

    public override void Enter()
    {
        remainingCastTime = currentSkill.SpellCastTime;
        stateMachine.Animator.CrossFadeInFixedTime(currentSkill.AnimationName, currentSkill.TransitionDuration);

        GameObject _skillInstance = stateMachine.SpawnGameObject(currentSkill.Prefab, stateMachine.SkillPoint.transform);
        stateMachine.DestroyGameObject(_skillInstance, currentSkill.SpellCastTime);
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
