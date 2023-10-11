
// Interface for objects that can attack or be attacked.
interface IAttackable
{
    // Perform an attack
    int Attack();

    // Take damage from an attack
    void TakeDamage(int amount);
}
