using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart_Cart
{
    public class ShoppingCart
    {
        public List<Product> items;
        public ProductGenerator productGenerator;

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
           

            Console.Write("\n");
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
            string response = Console.ReadLine() .ToLower();
            if (response=="yes")
            {
                AddRandomProducts();
            }
            Console.WriteLine("\n");
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
            Console.WriteLine("\n");
            Console.WriteLine("Enter the name of the product you want to add to your cart:");
            string productName = Console.ReadLine().ToLower();
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
            Console.WriteLine("\n");
        }

        public decimal CalculateTotalCost()
        {
            return items.Sum(item => item.Price);
        }

       
    }
}
