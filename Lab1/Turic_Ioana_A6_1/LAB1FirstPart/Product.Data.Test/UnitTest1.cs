using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Data;
using FluentAssertions;

namespace Product.Data.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GivenValueForIdWhenGetIdThenReturnValidId()
        {
            //Arrange
           Product product = new Product();
           //Act
           var id = product.Id = 10;
           //Assert
           id.Should().BePositive();
        }

        [TestMethod]
        public void GivenValueForNameWhenGetNameThenReturnValidName()
        {
            //Arrange
           Product product = new Product();
           //Act
           var name = product.Name = "Chocolate";
           //Assert
           name.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void GivenValueForDescriptionWhenGetDescriptionThenReturnValidDescription()
        {
            //Arrange
           Product product = new Product();
           //Act
           var description = product.Description = "Just as good as Milka";
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
            Product product = new Product();
           //Act
           var startDate = product.StartDate =  new System.DateTime(2018,09,30);
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
            Product product = new Product();
           //Act
           var startDate = product.EndDate =  new System.DateTime(2018,10,04);
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
           Product product = new Product();
           //Act
           var price = product.Price = 10;
           //Assert
           price.Should().BePositive();
           price.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateLowerThanEndDateThenReturnTrue()
        {
            // Arrange
            var product = new Product();
            //Act
            var result = product.IsValid(new System.DateTime(2018,09,30), new System.DateTime(2018,10,28));
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateEqualsToEndDateThenReturnTrue()
        {
            // Arrange
            var product = new Product();
            //Act
            var result = product.IsValid(new System.DateTime(2018,09,30), new System.DateTime(2018,09,30));
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateBiggerThanEndDateThenReturnFalse()
        {
            // Arrange
            var product = new Product();
            //Act
            var result = product.IsValid(new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Assert
            Assert.IsFalse(result);
        }

         [TestMethod]
         public void GiventComputeVATWhenPriceLowerThan100ThenReturnSpecificVTA()
         {
             //Arrange
             var product = new Product();
             //Act
             var result = product.ComputeVAT(99);
             //Assert
             Assert.AreEqual(result,(99*9)/100);
         }

         [TestMethod]
         public void GiventComputeVATWhenPriceEqualsTo100ThenReturnSpecificVTA()
         {
             //Arrange
             var product = new Product();
             //Act
             var result = product.ComputeVAT(100);
             //Assert
             Assert.AreEqual(result, 100*14/100);
         }

         [TestMethod]
         public void GiventComputeVATWhenPriceBiggerThan100ThenReturnSpecificVTA()
         {
             //Arrange
             var product = new Product();
             //Act
             var result = product.ComputeVAT(101);
             //Assert
             Assert.AreEqual(result, 100*14/100);
         }
    }
}
