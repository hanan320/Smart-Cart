using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart_Cart
{
    public class ShoppingCart
    {
        private List<Product> items;
        private ProductGenerator productGenerator;

        public ShoppingCart()
        {
            items = new List<Product>();
            productGenerator = new ProductGenerator();
        }

        public void AddItem(Product product)
        {
            items.Add(product);
        }

        public bool RemoveItem(string productName)
        {
            var product = items.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                items.Remove(product);
                return true;
            }
            return false;
        }

        public void ViewCart()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                Console.WriteLine("Items in your cart:");
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Name} - ${item.Price} ({item.Category})");
                }
            }

            // Option to add new random products
            Console.WriteLine("\nWould you like to add some random products? (yes/no)");
            string response = Console.ReadLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                AddRandomProducts();
            }
        }

        private void AddRandomProducts()
        {
            var randomProducts = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                randomProducts.Add(productGenerator.GenerateProduct());
            }

            Console.WriteLine("\nAvailable Random Products:");
            foreach (var product in randomProducts)
            {
                Console.WriteLine($"{product.Name} - ${product.Price} ({product.Category})");
            }

            Console.WriteLine("Enter the name of the product you want to add to your cart:");
            string productName = Console.ReadLine();
            var selectedProduct = randomProducts.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (selectedProduct != null)
            {
                AddItem(selectedProduct);
                Console.WriteLine($"{selectedProduct.Name} has been added to your cart.");
            }
            else
            {
                Console.WriteLine("Product not found in the random products list.");
            }
        }

        public decimal CalculateTotalCost()
        {
            return items.Sum(item => item.Price);
        }

        // Optional: Method to clear the cart
        public void ClearCart()
        {
            items.Clear();
            Console.WriteLine("Your cart has been cleared.");
        }
    }
}
