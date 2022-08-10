using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }

    [field: SerializeField] public float PlayerChasingRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; }
    [field: SerializeField] public Transform AttackPoint { get; private set; }

    public GameObject Player { get; private set; }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SwitchState(new EnemyChasingState(this));
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        SwitchState(new EnemyHurtingState(this));
    }

    private void HandleDie()
    {
        SwitchState(new EnemyDeathState(this));
    }

    // Events
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, LayerMask.GetMask("Player"));

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
