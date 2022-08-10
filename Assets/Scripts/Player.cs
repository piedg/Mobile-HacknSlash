using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D Rigidbody;
    [SerializeField] Animator Animator;
    [SerializeField] InputManager Inputs;
    [SerializeField] Health Health;

    [Header("Movement Settings")]
    [SerializeField] float MovementSpeed;

    [Header("Attack Settings")]
    [SerializeField] int AttackDamage;
    [SerializeField] float AttackRate;
    [SerializeField] float AttackRange;
    [SerializeField] Transform AttackPoint;

    [SerializeField] Image HealthBar;

    private readonly int LocomotionSpeedHash = Animator.StringToHash("LocomotionSpeed");
    private readonly int AttackHash = Animator.StringToHash("Attack");
    private readonly int DeadHash = Animator.StringToHash("Dead");

    private Vector2 direction;

    void Update()
    {
        if(Health.IsDead)
        {
            Rigidbody.velocity = Vector2.zero;
            Animator.SetBool(DeadHash, true);
            return;
        }

        direction = Inputs.MovementValue;
        direction.Normalize();

        UpdateLocomotion(direction);
        FlipSprite(direction.x);

        if(Inputs.IsAttacking)
        {
            StartAttacking();
        }
        else
        {
            StopAttacking();
        }

        HandleHealthBar();
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = direction * MovementSpeed;
    }

    void StartAttacking()
    {
        Rigidbody.velocity = Vector2.zero;
        Animator.SetTrigger(AttackHash);
    }

    void StopAttacking()
    {
        Animator.ResetTrigger(AttackHash);
    }

    void UpdateLocomotion(Vector2 direction)
    {
        if(direction == Vector2.zero)
        {
            Animator.SetFloat(LocomotionSpeedHash, 0f);
        }
        else
        {
            Animator.SetFloat(LocomotionSpeedHash, 1f);
        }
    }

    void FlipSprite(float directionX)
    {
        if (directionX > 0)
        {
            HealthBar.gameObject.transform.localScale = Vector2.one; 
            transform.localScale = Vector2.one;
        }
        else if (directionX < 0)
        {
            HealthBar.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void HandleHealthBar()
    {
        HealthBar.fillAmount = (float)Health.GetHealth() / (float)Health.maxHealth;
    }

 
    // Events
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, LayerMask.GetMask("Enemy"));

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().DealDamage(AttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
