using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth_TEAM26 : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    private bool isDead = false;
    private SpriteRenderer spriteRenderer;

    public float invincibilityDuration = 1f; // seconds
    private bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead || isInvincible) return;

        currentHealth -= amount;

        Debug.Log("Player took damage! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
        else
        {
            // Start invincibility + blinking
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    void GameOver()
    {
        isDead = true;
        UIManager_TEAM26 ui = Object.FindFirstObjectByType<UIManager_TEAM26>();
        if (ui != null)
        {
            ui.ShowGameOver();
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        float elapsed = 0f;

        while (elapsed < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(0.1f); // blink speed
            elapsed += 0.1f;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}
