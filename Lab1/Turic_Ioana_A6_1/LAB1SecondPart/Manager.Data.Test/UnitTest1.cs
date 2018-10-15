using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Manager.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
         [TestMethod]
        public void GivenValueForIdWhenGetIdThenReturnValidId()
        {
            //Arrange
           Manager manager = new Manager();
           //Act
           var id = manager.Id = 10;
           //Assert
           id.Should().BePositive();
        }

        [TestMethod]
        public void GivenValueForFirstNameWhenGetFirstNameThenReturnValidFirstName()
        {
            //Arrange
           Manager manager = new Manager();
           //Act
           var firstName = manager.FirstName = "Christian";
           //Assert
           firstName.Should().NotBeNullOrEmpty();
           firstName.Should().BeEquivalentTo("CHRISTIAN");
        }

        [TestMethod]
        public void GivenValueForLastNameWhenGetLastNameThenReturnValidLastName()
        {
            //Arrange
           Manager manager = new Manager();
           //Act
           var lastName = manager.LastName = "Jones";
           //Assert
           lastName.Should().NotBeNullOrEmpty();
           lastName.Should().BeEquivalentTo("JONES");
        }


        [TestMethod]
        public void GivenValueForStartDateWhenGetStartDateThenReturnValidStartDate()
        {
            //Arrange
            Manager manager = new Manager();
           //Act
           var startDate = manager.StartDate =  new System.DateTime(2018,09,30);
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
            Manager manager = new Manager();
           //Act
           var startDate = manager.EndDate =  new System.DateTime(2018,10,04);
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
          Manager manager = new Manager();
           //Act
           var salary = manager.Salary = 1650;
           //Assert
           salary.Should().BePositive();
           salary.Should().BeGreaterThan(1236);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateLowerThanEndDateThenReturnTrue()
        {
            // Arrange
            var manager = new Manager();
            //Act
            var result = manager.IsActive(new System.DateTime(2018,09,30), new System.DateTime(2018,10,28));
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateEqualsToEndDateThenReturnTrue()
        {
            // Arrange
            var manager = new Manager();
            //Act
            var result = manager.IsActive(new System.DateTime(2018,09,30), new System.DateTime(2018,10,30));
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateBiggerThanEndDateThenReturnFalse()
        {
            // Arrange
            var manager = new Manager();
            //Act
            var result = manager.IsActive(new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenFirstNameIsNullThenThrowException()
        {
            // Arrange
            var manager = new Manager();
            //Act
            var result = manager.GetFullName(null,"Jones");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenLastNameIsNullThenThrowException()
        {
            // Arrange
            var manager = new Manager();
            //Act
            var result = manager.GetFullName("Christian",null);
            //Assert
        }

        [TestMethod]
        public void GiventGetFullNameWhenBothAreValidThenReturnFullName()
        {
            //Arrange
            var manager = new Manager();
            //Act
            var result = manager.GetFullName("Christian","Jones");
            //Assert
            Assert.AreEqual(result,"Christian Jones");
        }
    }
}
