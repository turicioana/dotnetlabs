using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;



namespace Product.Data.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private const string PRODUCT = "Chocolate";
        private Product product1 = new Product(10,"Chocolate", "very good",new DateTime(2018,10,03), new DateTime(2018,10,10),5);


        private ProductRepository products;

        [TestInitialize]
        public void TestInitialize()
        {
            products = new ProductRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            products = null;
        }

        [TestMethod]
        public void When_ClassIsInstanciated_ThenShould_Have3Elements()
        {
            // Assert
            Assert.IsTrue(products.Capacity() == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_ProductNameIsNull_ThenShould_ThrowException()
        {
            products.GetProductByName(null); 
        }

        [TestMethod]
        public void When_ProductNameIsValid_ThenShould_ReturnValidProduct()
        {
            //Act
            Product result = (Product) products.GetProductByName(PRODUCT);
            //Assert
            Assert.IsTrue(result.Name == PRODUCT);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_AddedNullProduct_ThenShould_ThrowException()
        {
            products.AddProduct(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_RemoveProductWithNullName_ThenShould_ThrowException()
        {
            products.RemoveProductByName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_IndexIsRightOutOfRange_ThenShould_ThrowException()
        {
            // Arrange && Act
            products.GetProductByPosition(products.Capacity() + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_IndexIsLeftOutOfRange_ThenShould_ThrowException()
        {
            // Arrange && Act
            products.GetProductByPosition(-1);
        }

        [TestMethod]
        public void When_Corect_ThenShould_Result1()
        {
            // Arrange && Act
            Product productByPosition = (Product) products.GetProductByPosition(0);
            // Assert
            Assert.IsTrue(productByPosition.Name == product1.Name);
        }
    }
}
