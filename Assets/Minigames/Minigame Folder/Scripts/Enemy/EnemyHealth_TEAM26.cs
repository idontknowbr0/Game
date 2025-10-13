using System.Collections;
using UnityEngine;

public class EnemyHealth_TEAM26 : MonoBehaviour
{
    public int health = 1;
    private Animator animator;
    private bool isDead = false;
    void Start()
    {
        // Make sure animator is assigned
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        isDead = true;

        animator.SetTrigger("Die");

        EnemyMovement_TEAM26 movement = GetComponent<EnemyMovement_TEAM26>();
        if (movement != null) movement.enabled = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
