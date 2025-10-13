using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior_TEAM26 : ProjectileWeaponBehavior_TEAM26
{
    KnifeController_TEAM26 kc;
    protected override void Start()
    {
        base.Start();
        kc = Object.FindFirstObjectByType<KnifeController_TEAM26>();
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
            EnemyHealth_TEAM26 enemy = other.GetComponent<EnemyHealth_TEAM26>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            Destroy(gameObject); // destroy knife on hit
        }
    }
}
