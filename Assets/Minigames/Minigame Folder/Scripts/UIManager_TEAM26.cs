using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager_TEAM26 : MonoBehaviour, MinigameSubscriber
{
    public PlayerHealth_TEAM26 player;       // Reference to PlayerHealth
    public PlayerInventory_TEAM26 inventory;
    public TMP_Text healthText;       // Reference to health UI
    public TMP_Text potionText;

    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject instructionPanel;

    private bool gameStarted = false;

    private void Start()
    {
        MinigameManager.Subscribe(this);
        ShowStart();
    }
    void Update()
    {
        UpdateGameplayUI();
    }

    void UpdateGameplayUI()
    {
        if (player != null)
        {
            healthText.text = "Health: " + player.currentHealth;
            potionText.text = "Potions: " + inventory.potionsCollected;
        }
    }

    public void ShowStart()
    {
        Time.timeScale = 0f;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        instructionPanel.SetActive(false);
    }

    public void ShowInstructions()
    {
        startPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        instructionPanel.SetActive(false);

        MinigameManager.singleton.BeginMinigameCountdown();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        winPanel.SetActive(false);
    }

    public void ShowWin()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMinigameStart()
    {
        startPanel.SetActive(false);
        instructionPanel.SetActive(false);
        gameStarted = true;
    }

    public void OnTimerEnd()
    {
        // When the timer ends, decide if it's success/failure
        if (inventory.potionsCollected >= inventory.totalPotions)
        {
            ShowWin();
            MinigameManager.SetStateToSuccess();
            MinigameManager.EndGame();
        }
        else
        {
            ShowGameOver();
            MinigameManager.SetStateToFailure();
            MinigameManager.EndGame();
        }

        MinigameManager.EndGame();
    }
}
