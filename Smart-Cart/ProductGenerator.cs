using System;

namespace Smart_Cart
{
    public class ProductGenerator
    {
        private static readonly Random random = new Random();

        public Product GenerateProduct()
        {
            string[] productNames = { "Grapes", "T-shirt", "Socks", "Tablet", "Charger", "Smoothie" };
            decimal[] productPrices = { 2.99m, 15.99m, 5.99m, 299.99m, 29.99m, 3.49m };
            ProductCategory[] categories =
            {
                ProductCategory.Food,
                ProductCategory.Clothing,
                ProductCategory.Clothing,
                ProductCategory.Electronics,
                ProductCategory.Electronics,
                ProductCategory.Food
            };

            int index = random.Next(productNames.Length);
            string name = productNames[index];
            decimal price = productPrices[index];
            ProductCategory category = categories[index];

            return new Product(name, price, category);
        }
    }
}
