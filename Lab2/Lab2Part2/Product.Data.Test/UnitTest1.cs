using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;


namespace Product.Data.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GivenValueForIdWhenGetIdThenReturnValidId()
        {
            //Arrange
           Product product = new Product(10,"Chocolate", "very good",new DateTime(2018,10,03), new DateTime(2018,10,10),5);
           //Act
           var id = product.Id;
           //Assert
           id.Should().BePositive();
        }

        [TestMethod]
        public void GivenValueForNameWhenGetNameThenReturnValidName()
        {
            //Arrange
           Product product = new Product(10,"Chocolate", "very good",new DateTime(2018,10,03), new DateTime(2018,10,10),5);
           //Act
           var name = product.Name;
           //Assert
           name.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void GivenValueForDescriptionWhenGetDescriptionThenReturnValidDescription()
        {
            //Arrange
           Product product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,10,03), new DateTime(2018,10,10),5);
           //Act
           var description = product.Description;
           //Assert
           description.Should().NotBeNull();
           description.Should().Be("Just as good as Milka");
           description.Should().NotBe("Nothing here");
           description.Should().BeEquivalentTo("JUST AS GOOD AS MILKA");
        }

        [TestMethod]
        public void GivenValueForStartDateWhenGetStartDateThenReturnValidStartDate()
        {
            //Arrange
            Product product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,10,10),5);
           //Act
           var startDate = product.StartDate;
           //Assert
           startDate.Should().HaveDay(30);
           startDate.Should().HaveMonth(09);
           startDate.Should().HaveYear(2018);
           startDate.Should().NotBeOnOrBefore(new System.DateTime(2018,01,01));
        }

        [TestMethod]
        public void GivenValueForEndDateWhenGetEndDateThenReturnValidEndDate()
        {
            //Arrange
            Product product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,10,04),5);
           //Act
           var startDate = product.EndDate;
           //Assert
           startDate.Should().HaveDay(04);
           startDate.Should().HaveMonth(10);
           startDate.Should().HaveYear(2018);
           startDate.Should().NotBeOnOrBefore(new System.DateTime(2018,01,01));
        }

        [TestMethod]
        public void GivenValueForIPriceWhenGetPriceThenReturnValidPrice()
        {
            //Arrange
           Product product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,10,10),10);
           //Act
           var price = product.Price;
           //Assert
           price.Should().BePositive();
           price.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateLowerThanEndDateThenReturnTrue()
        {
            // Arrange
            var product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,10,28),5);
            //Act
            var result = product.IsValid(product.StartDate,product.EndDate);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateEqualsToEndDateThenReturnTrue()
        {
            // Arrange
            var product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,09,30),5);
            //Act
            var result = product.IsValid(product.StartDate,product.EndDate);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateBiggerThanEndDateThenReturnFalse()
        {
            // Arrange
            var product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,10,30), new DateTime(2018,10,10),5);
            //Act
            var result = product.IsValid(product.StartDate,product.EndDate);
            //Assert
            Assert.IsFalse(result);
        }

         [TestMethod]
         public void GiventComputeVATWhenPriceLowerThan100ThenReturnSpecificVTA()
         {
             //Arrange
             var product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,10,10),5);
             //Act
             var result = product.ComputeVAT(product.Price);
             //Assert
             Assert.AreEqual(result,(5*9)/100);
         }

         [TestMethod]
         public void GiventComputeVATWhenPriceEqualsTo100ThenReturnSpecificVTA()
         {
             //Arrange
             var product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,10,10),100);
             //Act
             var result = product.ComputeVAT(product.Price);
             //Assert
             Assert.AreEqual(result, 100*14/100);
         }

         [TestMethod]
         public void GiventComputeVATWhenPriceBiggerThan100ThenReturnSpecificVTA()
         {
             //Arrange
             var product = new Product(10,"Chocolate", "Just as good as Milka",new DateTime(2018,09,30), new DateTime(2018,10,10),150);
             //Act
             var result = product.ComputeVAT(product.Price);
             //Assert
             Assert.AreEqual(result, 150*14/100);
         }
    }
}
