
// Singleton Manager for controlling all sound effects and music in the game.
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Play a specific sound
    public void PlaySound(string soundName) {}
}
