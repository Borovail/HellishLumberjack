
// Concrete class for a shop where items can be bought.
public class Shop : BaseShop
{
    // Show available items in this specific shop
    public override void ShowItems() {}

    // Buy an item from this specific shop
    public override void BuyItem(string itemName) {}

    public override void Interact()
    {
        throw new System.NotImplementedException();
    }
}
