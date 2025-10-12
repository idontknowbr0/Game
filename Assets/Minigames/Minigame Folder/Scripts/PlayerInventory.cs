using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int potionsCollected = 0;
    public int totalPotions = 3; // Number of potions to win

    public void CollectPotion()
    {
        potionsCollected++;
        Debug.Log("Potion collected! Total: " + potionsCollected);

        if (potionsCollected >= totalPotions)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("Player collected all potions! You win!");

        // You can trigger any victory effects or scene transitions here
        SceneManager.LoadScene("Victory");
    }
}
