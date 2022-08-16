using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField, Header("Controllers")] public InputManager InputManager { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2d { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }

    [field: SerializeField, Header("Movement Settings")] public float MovementSpeed { get; private set; }

    [field: SerializeField, Header("Health Settings")] public Image HealthBar { get; private set; }

    [field: SerializeField, Header("Attacks Settings")] public Transform AttackPoint { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }


    [field: SerializeField, Header("Skills Settings")] public Transform SkillPoint { get; private set; }
    [field: SerializeField] public Skill[] Skills { get; private set; }

    private void Start()
    {
        SwitchState(new PlayerMovementState(this));
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
        HandleHealthBar();
        // SwitchState(new PlayerImpactState(this)); Non implementato
    }

    private void HandleDie()
    {
       SwitchState(new PlayerDeadState(this));
    }

    void HandleHealthBar() => HealthBar.fillAmount = (float)Health.GetHealth() / (float)Health.maxHealth;

    // Animation Events

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

    public GameObject SpawnGameObject(GameObject prefab, Transform spawnPoint)
    {
        return Instantiate(prefab, spawnPoint);
    }

    public void DestroyGameObject(GameObject instance, float delay)
    {
        Destroy(instance, delay);
    }
}
