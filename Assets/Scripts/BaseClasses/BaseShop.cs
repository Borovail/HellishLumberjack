
 using UnityEngine;
// Abstract class for shops with basic functionalities.
abstract public class BaseShop : MonoBehaviour, IInteractable
{
    // Show available items in the shop
    public abstract void ShowItems();

    // Buy an item from the shop
    public abstract void BuyItem(string itemName);

    public abstract void Interact();

}
