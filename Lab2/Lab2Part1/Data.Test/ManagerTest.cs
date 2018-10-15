using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace Data.Test
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void GivenValueForFirstNameWhenGetFirstNameThenReturnValidFirstName()
        {
            //Arrange
           Manager manager = new Manager(1,4000,"Christian","Smth", new DateTime(2018,01,01), new DateTime(2018,10,30));
           //Act
           var firstName = manager.FirstName;
           //Assert
           firstName.Should().NotBeNullOrEmpty();
           firstName.Should().BeEquivalentTo("CHRISTIAN");
        }

        [TestMethod]
        public void GivenValueForLastNameWhenGetLastNameThenReturnValidLastName()
        {
            //Arrange
           Manager manager = new Manager(1,4000,"Christian","Jones", new DateTime(2018,01,01), new DateTime(2018,10,30));
           //Act
           var lastName = manager.LastName;
           //Assert
           lastName.Should().NotBeNullOrEmpty();
           lastName.Should().BeEquivalentTo("JONES");
        }


        [TestMethod]
        public void GivenValueForStartDateWhenGetStartDateThenReturnValidStartDate()
        {
            //Arrange
            Manager manager = new Manager(1,4000,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
           //Act
           var startDate = manager.StartDate;
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
            Manager manager = new Manager(1,4000,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
           //Act
           var startDate = manager.EndDate;
           //Assert
           startDate.Should().HaveDay(30);
           startDate.Should().HaveMonth(10);
           startDate.Should().HaveYear(2018);
           startDate.Should().NotBeOnOrBefore(new System.DateTime(2010,01,01));
        }

        [TestMethod]
        public void GivenValueForSalaryWhenGetSalaryThenReturnValidSalary()
        {
            //Arrange
          Manager manager = new Manager(1,1650,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
           //Act
           var salary = manager.Salary;
           //Assert
           salary.Should().BePositive();
           salary.Should().BeGreaterThan(1236);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateLowerThanEndDateThenReturnTrue()
        {
            // Arrange
            var manager = new Manager(1,4000,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
            //Act
            var result = manager.IsActive(manager.StartDate,manager.EndDate);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateEqualsToEndDateThenReturnTrue()
        {
            // Arrange
            var manager = new Manager(1,4000,"Christian","Jones", new System.DateTime(2018,10,30), new DateTime(2018,10,30));
            //Act
            var result = manager.IsActive(manager.StartDate,manager.EndDate);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateBiggerThanEndDateThenReturnFalse()
        {
            // Arrange
            var manager = new Manager(1,4000,"Christian","Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = manager.IsActive(manager.StartDate,manager.EndDate);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenFirstNameIsNullThenThrowException()
        {
            // Arrange
            var manager = new Manager(1,4000,null,"Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = manager.GetFullName(manager.FirstName,manager.LastName);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenLastNameIsNullThenThrowException()
        {
            // Arrange
            var manager = new Manager(1,4000,"Christian",null,new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = manager.GetFullName(manager.FirstName,manager.LastName);
            //Assert
        }

        [TestMethod]
        public void GiventGetFullNameWhenBothAreValidThenReturnFullName()
        {
            //Arrange
            var manager = new Manager(1,4000,"Christian","Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = manager.GetFullName("Christian","Jones");
            //Assert
            Assert.AreEqual(result,"Christian Jones");
        }

        [TestMethod]
        public void TestSalutationValidArguments()
        {
            var manager = new Manager(1,4000,"Christian","Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            String result = manager.Salutation(manager.GetFullName(manager.FirstName,manager.LastName));
            Assert.IsTrue(result == "Hello manager Christian Jones");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestSalutationInvalidFirstName()
        {
            var manager = new Manager(1,4000,null,"Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            String result = manager.Salutation(manager.GetFullName(null, "Jones"));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestSalutationInvalidLastName()
        {
            var manager = new Manager(1,4000,"Christian",null,new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            String result = manager.Salutation(manager.GetFullName("Christian", null));
        }
    }
}