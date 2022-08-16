using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float AnimatorDumpTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    Vector2 direction;

    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionBlendTreeHash, CrossFadeDuration);
    }

    public override void Exit() { }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputManager.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
            return;
        }
            else if(stateMachine.InputManager.IsSkill1)
        { 
            stateMachine.SwitchState(new PlayerCastSkillState(stateMachine, 0));
            return;
        }
            else if (stateMachine.InputManager.IsSkill2)
        {
            stateMachine.SwitchState(new PlayerCastSkillState(stateMachine, 1));
            return;
        }

        direction = stateMachine.InputManager.MovementValue;
        direction.Normalize();

        FlipSprite(direction.x);
        UpdateLocomotion(direction, deltaTime);

        Move(direction, stateMachine.MovementSpeed);
    }

    void UpdateLocomotion(Vector2 direction, float deltaTime)
    {
        if (direction == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDumpTime, deltaTime);
        }
        else
        {
            stateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDumpTime, deltaTime);
        }
    }
}