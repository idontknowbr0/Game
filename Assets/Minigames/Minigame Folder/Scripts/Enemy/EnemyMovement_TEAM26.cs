using UnityEngine;

public class EnemyMovement_TEAM26 : MonoBehaviour
{
    Transform player;
    public float moveSpeed;
    Animator animator;

    public float attackRange = 1.5f;       // Distance at which enemy attacks
    public float attackCooldown = 1f;      // Seconds between attacks

    private float cooldownTimer = 1f;


    void Start()
    {
        player = Object.FindFirstObjectByType<PlayerController_TEAM26>().transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        Vector2 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (direction.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector3(1, 1, 1);

        if (distance <= attackRange && cooldownTimer <= 0f)
        {
            Attack();
            cooldownTimer = attackCooldown;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime); //Constantly moves the enemy towards the player
            
            if (animator != null)
            {
                bool isRunning = direction.magnitude > 0.01f; // only true if enemy is moving
                animator.SetBool("isRunning", isRunning);
            
            }
        }
    }
    void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Optional: Deal damage to the player here
        player.GetComponent<PlayerHealth_TEAM26>()?.TakeDamage(1);
    }
}
