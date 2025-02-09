using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundCounter : MonoBehaviour
{
    // Reference to the TextMeshPro text that displays round info.
    public TMP_Text roundText;
    
    // Reference to a panel (or GameObject) that holds the Game Over message and restart button.
    public GameObject gameOverPanel;
    
    // Reference to the restart button.
    public Button restartButton;

    // Persist the current round across scene loads.
    public static int currentRound = 1;
    
    // Total rounds before game over.
    [SerializeField]
    private int maxRounds = 4;

    void Start()
    {
        // Update the round text on start.
        UpdateRoundCounter();

        // Hide the Game Over panel at the start.
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // Optionally, assign the restart button's click event.
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
    }

    // This method is called when a branch is caught or when rounds run out.
    public void EndGame()
    {
        // Display "Game Over" in the round text.
        roundText.text = "BOOO";
        
        // Activate the Game Over panel, which might contain a restart button.
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        // Stop the game by pausing the time scale.
        Time.timeScale = 0f;
    }

    // This method is called when advancing to the next round (if applicable).
    public void NextRound()
    {
        if (currentRound < maxRounds)
        {
            currentRound++;
            // Reload the scene so that the new round begins.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            EndGame();
        }
    }

    // Update the UI text to show the current round.
    private void UpdateRoundCounter()
    {
        if (currentRound <= maxRounds)
        {
            roundText.text = "Round " + currentRound;
        }
        else
        {
            roundText.text = "BOOOO";
        }
        Debug.Log("Updated round text: " + roundText.text);
    }

    // This method is linked to the restart button.
    public void RestartGame()
    {
        // Reset the time scale so the game resumes.
        Time.timeScale = 1f;
        
        // Optionally, reset the round counter for a new game.
        currentRound = 1;
        // Reload the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BranchCaught()
    {
        // For example, simply call EndGame()
        EndGame();
    }

}
