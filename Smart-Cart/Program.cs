using Smart_Cart;

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        Shop groceryStore = new GroceryStore();
        Shop clothingStore = new ClothingStore();
        Shop electronicsStore = new ElectronicsStore();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Shop at Grocery Store");
            Console.WriteLine("2. Shop at Clothing Store");
            Console.WriteLine("3. Shop at Electronics Store");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Remove Item from Cart");
            Console.WriteLine("6. Checkout and Exit");
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "1")
            {
                ShopAtStore(groceryStore, cart);
            }
            else if (choice == "2")
            {
                ShopAtStore(clothingStore, cart);
            }
            else if (choice == "3")
            {
                ShopAtStore(electronicsStore, cart);
            }
            else if (choice == "4")
            {
                cart.ViewCart();
                Console.WriteLine($"Total Cost: ${cart.CalculateTotalCost()}");
            }
            else if (choice == "5")
            {
                if (cart.items.Count == 0)
                {
                    Console.WriteLine("Your cart is empty.");
                }
                else
                {
                    Console.WriteLine("Items in your cart:");
                    foreach (var item in cart.items) // Corrected this line
                    {
                        Console.WriteLine($"{item.Name} - ${item.Price} ({item.Category})");
                    }
                }

                Console.Write("\nEnter the name of the product to remove from cart: ");
                string productName = Console.ReadLine();

                bool removed = cart.RemoveItem(productName); // Fixed method call

                if (removed)
                {
                    Console.WriteLine($"The item has been removed from your cart.\n");
                }
                else
                {
                    Console.WriteLine("Product not found in the cart.\n");
                }
            }
            else if (choice == "6" || choice == "exit")
            {
                exit = true;
                Console.WriteLine($"Total Cost: ${cart.CalculateTotalCost()}");
                Console.WriteLine("Thank you for shopping with us!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

    static void ShopAtStore(Shop store, ShoppingCart cart)
    {
        bool shopExit = false;
        while (!shopExit)
        {
            Console.WriteLine("\n");
            store.DisplayProducts();
            Console.WriteLine("\n");
            Console.Write("Enter the name of the product to add to cart (or type 'exit' to go back): ");
            string productName = Console.ReadLine().ToLower();
            Console.WriteLine("\n");

            if (productName == "exit")
            {
                shopExit = true;
            }
            else
            {
                var product = store.GetProduct(productName);
                if (product != null)
                {
                    cart.AddItem(product);
                    Console.WriteLine($"{product.Name} has been added to your cart.");
                    Console.WriteLine($"Current Total Cost: ${cart.CalculateTotalCost()}");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
        }
    }
}
