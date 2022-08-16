using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMeteor : MonoBehaviour
{
    [SerializeField] CircleCollider2D CircleCollider;
    [SerializeField] int Damage;

    private void Update()
    {
        transform.Translate(Vector2.down * 1f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Health>().DealDamage(Damage);
    }

    // Animations Events
    void Skill_Hit()
    {
        CircleCollider.enabled = true;
    }

    void Skill_End()
    {
        Destroy(gameObject);
    }
}
