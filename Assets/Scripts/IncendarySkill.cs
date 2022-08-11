using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncendarySkill : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] BoxCollider2D BoxCollider;
    [SerializeField] int Damage;

    void Skill_Incendary()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, Range, LayerMask.GetMask("Enemy"));

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().DealDamage(Damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (transform.position == null) return;

        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
