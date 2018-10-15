using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Architect.Data.Test
{
    [TestClass]
    public class ArchitectTest
    {
       [TestMethod]
        public void GivenValueForIdWhenGetIdThenReturnValidId()
        {
            //Arrange
           Architect architect = new Architect();
           //Act
           var id = architect.Id = 10;
           //Assert
           id.Should().BePositive();
        }

        [TestMethod]
        public void GivenValueForFirstNameWhenGetFirstNameThenReturnValidFirstName()
        {
            //Arrange
           Architect architect = new Architect();
           //Act
           var firstName = architect.FirstName = "Christian";
           //Assert
           firstName.Should().NotBeNullOrEmpty();
           firstName.Should().BeEquivalentTo("CHRISTIAN");
        }

        [TestMethod]
        public void GivenValueForLastNameWhenGetLastNameThenReturnValidLastName()
        {
            //Arrange
           Architect architect = new Architect();
           //Act
           var lastName = architect.LastName = "Jones";
           //Assert
           lastName.Should().NotBeNullOrEmpty();
           lastName.Should().BeEquivalentTo("JONES");
        }


        [TestMethod]
        public void GivenValueForStartDateWhenGetStartDateThenReturnValidStartDate()
        {
            //Arrange
           Architect architect = new Architect();
           //Act
           var startDate = architect.StartDate =  new System.DateTime(2018,09,30);
           //Assert
           startDate.Should().HaveDay(30);
           startDate.Should().HaveMonth(09);
           startDate.Should().HaveYear(2018);
           startDate.Should().NotBeOnOrBefore(new System.DateTime(2010,01,01));
        }

        [TestMethod]
        public void GivenValueForEndDateWhenGetEndDateThenReturnValidEndDate()
        {
            //Arrange
           Architect architect = new Architect();
           //Act
           var startDate = architect.EndDate =  new System.DateTime(2018,10,04);
           //Assert
           startDate.Should().HaveDay(04);
           startDate.Should().HaveMonth(10);
           startDate.Should().HaveYear(2018);
           startDate.Should().NotBeOnOrBefore(new System.DateTime(2010,01,01));
        }

        [TestMethod]
        public void GivenValueForSalaryWhenGetSalaryThenReturnValidSalary()
        {
            //Arrange
           Architect architect = new Architect();
           //Act
           var salary = architect.Salary = 1650;
           //Assert
           salary.Should().BePositive();
           salary.Should().BeGreaterThan(1236);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateLowerThanEndDateThenReturnTrue()
        {
            // Arrange
           Architect architect = new Architect();
            //Act
            var result = architect.IsActive(new System.DateTime(2018,09,30), new System.DateTime(2018,10,28));
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateEqualsToEndDateThenReturnTrue()
        {
            // Arrange
           Architect architect = new Architect();
            //Act
            var result = architect.IsActive(new System.DateTime(2018,09,30), new System.DateTime(2018,09,30));
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsValidWhenStartDateBiggerThanEndDateThenReturnFalse()
        {
            // Arrange
           Architect architect = new Architect();
            //Act
            var result = architect.IsActive(new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenFirstNameIsNullThenThrowException()
        {
            // Arrange
           Architect architect = new Architect();
            //Act
            var result = architect.GetFullName(null,"Jones");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenLastNameIsNullThenThrowException()
        {
            // Arrange
           Architect architect = new Architect();
            //Act
            var result = architect.GetFullName("Christian",null);
            //Assert
        }

        [TestMethod]
        public void GiventGetFullNameWhenBothAreValidThenReturnFullName()
        {
            //Arrange
           Architect architect = new Architect();
            //Act
            var result = architect.GetFullName("Christian","Jones");
            //Assert
            Assert.AreEqual(result,"Christian Jones");
        }
    }
}
