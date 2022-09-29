using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private readonly int AttackSpeedHash = Animator.StringToHash("AttackSpeed");

    private float previousFrameTime;

    private Attack currentAttack;
    Vector2 direction;

    public PlayerAttackingState(PlayerStateMachine stateMachine, int attackId) : base(stateMachine)
    {
        currentAttack = stateMachine.Attacks[attackId];
    }

    public override void Enter()
    {
        stateMachine.Animator.SetFloat(AttackSpeedHash, stateMachine.AttackSpeed);

        stateMachine.Animator.CrossFadeInFixedTime(currentAttack.AnimationName, currentAttack.TransitionDuration);
    }

    public override void Exit() { }

    public override void Tick(float deltaTime)
    {

        direction = stateMachine.InputManager.MovementValue;

        FlipSprite(direction.x);
        Move(direction, 0f);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");
        

        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if (stateMachine.InputManager.IsAttacking)
            {
                TryCombo(normalizedTime);
            }
        }
        else
        {
            stateMachine.SwitchState(new PlayerMovementState(stateMachine));
        }

        previousFrameTime = normalizedTime;
    }

    void TryCombo(float normalizedTime)
    {
        if(currentAttack.ComboStateIndex == -1) { return; }

        if(normalizedTime < currentAttack.ComboAttackTime) { return; }

        stateMachine.SwitchState(new PlayerAttackingState(stateMachine, currentAttack.ComboStateIndex));
    }
}
