using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : ProjectileWeaponBehavior
{
    KnifeController kc;
    protected override void Start()
    {
        base.Start();
        kc = Object.FindFirstObjectByType<KnifeController>();
    }
    void Update()
    {
        transform.position += direction * kc.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Damage the enemy if it has EnemyHealth
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            Destroy(gameObject); // destroy knife on hit
        }
    }
}
