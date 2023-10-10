
 using UnityEngine;
// Class for controlling the player's movements and actions like attacking and gathering resources.
public class PlayerController : MonoBehaviour, IAttackable
{
    public delegate void HealthChangedEvent(int newHealth);
    public event HealthChangedEvent OnHealthChanged;

    int newHealth = 0;

    // Logic for player movement
    public void Move() {}

    // Logic for player's attack
    public void Attack() {}

    // Logic when player takes damage
    public void TakeDamage(int amount)
    {
        // Update health
        OnHealthChanged?.Invoke(newHealth);
    }

    // Logic for collecting resources
    public void CollectResource() {}
}
