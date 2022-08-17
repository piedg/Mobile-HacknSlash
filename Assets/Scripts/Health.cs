using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int maxHealth = 100;

    private int health;
    private bool isInvulnerable;

    public event Action OnTakeDamage;
    public event Action OnDie;

    public bool IsDead => health == 0;

    private void Start()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }

    public void DealDamage(int damage)
    {
//        if (isInvulnerable) { return; }

        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        if (IsDead)
        {
            if(CompareTag("Enemy"))
            {
                GameManager.Instance.KillCount++;
            }

            OnDie?.Invoke();
            return;
        }
    }
}
