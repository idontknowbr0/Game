using UnityEngine;
using TMPro;

public class UIManager_TEAM226 : MonoBehaviour
{
    public PlayerHealth player;       // Reference to PlayerHealth
    public PlayerInventory inventory;
    public TMP_Text healthText;       // Reference to health UI
    public TMP_Text potionText;

    void Update()
    {
        if (player != null)
        {
            healthText.text = "Health: " + player.currentHealth;
            potionText.text = "Potions: " + inventory.potionsCollected;
        }
    }
}
