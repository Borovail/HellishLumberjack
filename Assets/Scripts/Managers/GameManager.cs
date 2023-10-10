using UnityEngine;

// Singleton Manager for controlling the overall game state, events, and transitions between different states (pause, resume, game over).
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void GameEvent();
    public static event GameEvent OnGameStarted;
    public static event GameEvent OnGameEnded;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start the game
    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    // Pause the game
    public void PauseGame() {}

    // End the game
    public void EndGame()
    {
        OnGameEnded?.Invoke();
    }
}
