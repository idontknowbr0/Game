using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory_TEAM26 : MonoBehaviour
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

        UIManager_TEAM26 ui = Object.FindFirstObjectByType<UIManager_TEAM26>();
        if (ui != null)
        {
            ui.ShowWin();
        }
    }
}
