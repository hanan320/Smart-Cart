using System;
using System.IO;
using Smart_Cart;

namespace Smart_Cart_Test
{
    public class UnitTest
    {
        private ShoppingCart _cart;
        private Product _apple;
        private Product _banana;
        private Product _jeans;

        public void SetUp()
        {
            _cart = new ShoppingCart();
            _apple = new Product("Apple", 1.99m, ProductCategory.Food);
            _banana = new Product("Banana", 0.99m, ProductCategory.Food);
            _jeans = new Product("Jeans", 49.99m, ProductCategory.Clothing);
        }
        [Fact]
        public void AddItem_test()
        { 
            SetUp();

            _cart.AddItem(_apple);
            _cart.AddItem(_banana);

            int result= _cart.items.Count;

            Assert.Equal(2, result);

        }
        [Fact]
        public void RemoveItem_test() {

            SetUp();

            _cart.AddItem(_apple);
            _cart.AddItem(_banana);
            _cart.RemoveItem(_apple.Name);

            int result= _cart.items.Count;

            Assert.Equal(1, result);


        }
        [Fact]
        public void calc_cost_test()
        {

            SetUp();

            _cart.AddItem(_apple);
            _cart.AddItem(_banana);

            decimal result = _apple.Price+_banana.Price;

            Assert.Equal(2.98m, result);


        }


    }
}
