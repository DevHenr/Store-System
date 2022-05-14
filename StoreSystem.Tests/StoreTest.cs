using System;
using Xunit;

namespace StoreSystem.Tests
{
    public class StoreTest
    {
        [Fact]
        public void VerifyBill()
        {
            //Arrange
            var store = new Store();

            var product1 = new Product("Plant pot", 10.50);
            var product2 = new Product("Coffee table", 329.45);

            store.ProductList.Add(product1);
            store.ProductList.Add(product2);

            store.ShoppingList.Add(store.ProductList[0]);
            store.ShoppingList.Add(store.ProductList[1]);

            //Act
            double bill = store.Bill();

            //Assert
            Assert.Equal(339.95, bill);
        }
    }
}
