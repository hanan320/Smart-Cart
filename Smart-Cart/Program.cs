using Smart_Cart;

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        Shop groceryStore = new GroceryStore();
        Shop clothingStore = new ClothingStore();
        Shop electronicsStore = new ElectronicsStore(); // Create instance of ElectronicsStore

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Shop at Grocery Store");
            Console.WriteLine("2. Shop at Clothing Store");
            Console.WriteLine("3. Shop at Electronics Store");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Checkout and Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

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
                ShopAtStore(electronicsStore, cart); // Handle shopping at ElectronicsStore
            }
            else if (choice == "4")
            {
                cart.ViewCart();
                Console.WriteLine($"Total Cost: ${cart.CalculateTotalCost()}");
            }
            else if (choice == "5")
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
            store.DisplayProducts();
            Console.Write("Enter the name of the product to add to cart (or type 'exit' to go back): ");
            string productName = Console.ReadLine();

            if (productName.Equals("exit", StringComparison.OrdinalIgnoreCase))
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
