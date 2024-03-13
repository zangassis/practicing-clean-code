namespace PracticingCleanCode.Models;

public class ShoppingCartBetter
{
    public void AddItem(string item)
    {
        Console.WriteLine("Item added to cart: " + item);
    }

    public void RemoveItem(string item)
    {
        Console.WriteLine("Item removed from cart: " + item);
    }

    class ShoppingCartServiceBetter
    {
        static void ProcessShoppingCart(ShoppingCart cart)
        {
            cart.AddItem("Product 1");
            cart.AddItem("Product 2");
            cart.RemoveItem("Product 1");
        }
    }
}