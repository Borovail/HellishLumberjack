
using UnityEngine;
// Singleton Manager for controlling the User Interface such as menus, health bars, etc.
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Update the health bar UI
    public void UpdateHealthBar(int health) {}

    // Show game menu
    public void ShowMenu() {}
}
