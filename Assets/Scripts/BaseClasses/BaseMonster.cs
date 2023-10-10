using UnityEngine;

// Abstract class for monsters with basic behavior.
abstract class BaseMonster : MonoBehaviour, IAttackable
{
    // Monster's attack logic
    public abstract void Attack();

    // Take damage logic for monster
    public abstract void TakeDamage(int amount);

    // Logic when the monster dies
    public abstract void Die();
}
