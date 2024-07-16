using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart
{
    public class Shop
    {
        protected List<Product> availableProducts;

        public Shop()
        {
            availableProducts = new List<Product>();
        }

        public void DisplayProducts()
        {
            Console.WriteLine($"{this.GetType().Name} Products:");
            foreach (var product in availableProducts)
            {
                Console.WriteLine($"{product.Name} - ${product.Price} ({product.Category})");
            }
        }
        public Product GetProduct(string productName)
        {
            return availableProducts.Find(p => p.Name.ToLower() == productName);
        }

        protected void AddProduct(Product product)
        {
            availableProducts.Add(product);
        }
    }

    public class GroceryStore : Shop
    {
        public GroceryStore()
        {
            AddProduct(new Product("Apple", 1.99m, ProductCategory.Food));
            AddProduct(new Product("Banana", 0.99m, ProductCategory.Food));
            AddProduct(new Product("Orange", 1.29m, ProductCategory.Food)); 
        }
    }


    public class ClothingStore : Shop
    {
        public ClothingStore()
        {
            AddProduct(new Product("Jeans", 49.99m, ProductCategory.Clothing));
            AddProduct(new Product("Shirt", 19.99m, ProductCategory.Clothing));
            AddProduct(new Product("Jacket", 89.99m, ProductCategory.Clothing));
        }
    }

    public class ElectronicsStore : Shop
    {
        public ElectronicsStore()
        {
            AddProduct(new Product("Laptop", 999.99m, ProductCategory.Electronics));
            AddProduct(new Product("Phone", 799.99m, ProductCategory.Electronics));
            AddProduct(new Product("Headphones", 149.99m, ProductCategory.Electronics));
            AddProduct(new Product("Smartwatch", 199.99m, ProductCategory.Electronics)); 
        }
    }
}
