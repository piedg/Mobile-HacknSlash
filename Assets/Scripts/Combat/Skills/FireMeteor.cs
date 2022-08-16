using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMeteor : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] CircleCollider2D CircleCollider;
    [SerializeField] int Damage;

    private void Update()
    {
        transform.Translate(Vector2.down * 1f * Time.deltaTime);
    }

    void Skill_FireMeteor()
    {
        //CircleCollider.enabled = true;
        //moodificare l'evento nell'animazione
    }

    private void OnDrawGizmosSelected()
    {
        if (transform.position == null) return;

        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>().DealDamage(Damage);
    }
}
