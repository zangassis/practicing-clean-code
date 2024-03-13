namespace PracticingCleanCode.Models;

public class ShoppingCart
{
    public void AddItem(string item)
    {
        Console.WriteLine("Item added to cart: " + item);
    }

    public void RemoveItem(string item)
    {
        Console.WriteLine("Item removed from cart: " + item);
    }

    public double CalculateTotal()
    {
        Console.WriteLine("Calculating total...");
        return 0.0;
    }

    public void PrintReceipt()
    {
        Console.WriteLine("Printing receipt...");
    }

    class ShoppingCartService
    {
        static void ProcessShoppingCart(ShoppingCart cart)
        {
            cart.AddItem("Product 1");
            cart.AddItem("Product 2");
            cart.RemoveItem("Product 1");
            double total = cart.CalculateTotal();
            Console.WriteLine("Total: $" + total);
        }
    }
}