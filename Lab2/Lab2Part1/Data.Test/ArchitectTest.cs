using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Data;

namespace Data.Test
{
   [TestClass]
    public class ArchitectTest
    {
        [TestMethod]
        public void GivenValueForFirstNameWhenGetFirstNameThenReturnValidFirstName()
        {
            //Arrange
           Architect architect = new Architect(1,4000,"Christian","Smth", new DateTime(2018,01,01), new DateTime(2018,10,30));
           //Act
           var firstName = architect.FirstName;
           //Assert
           firstName.Should().NotBeNullOrEmpty();
           firstName.Should().BeEquivalentTo("CHRISTIAN");
        }

        [TestMethod]
        public void GivenValueForLastNameWhenGetLastNameThenReturnValidLastName()
        {
            //Arrange
           Architect architect = new Architect(1,4000,"Christian","Jones", new DateTime(2018,01,01), new DateTime(2018,10,30));
           //Act
           var lastName = architect.LastName;
           //Assert
           lastName.Should().NotBeNullOrEmpty();
           lastName.Should().BeEquivalentTo("JONES");
        }


        [TestMethod]
        public void GivenValueForStartDateWhenGetStartDateThenReturnValidStartDate()
        {
            //Arrange
            Architect architect = new Architect(1,4000,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
           //Act
           var startDate = architect.StartDate;
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
            Architect architect = new Architect(1,4000,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
           //Act
           var startDate = architect.EndDate;
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
          Architect architect = new Architect(1,1650,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
           //Act
           var salary = architect.Salary;
           //Assert
           salary.Should().BePositive();
           salary.Should().BeGreaterThan(1236);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateLowerThanEndDateThenReturnTrue()
        {
            // Arrange
            var architect = new Architect(1,4000,"Christian","Jones", new System.DateTime(2018,09,30), new DateTime(2018,10,30));
            //Act
            var result = architect.IsActive(architect.StartDate,architect.EndDate);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateEqualsToEndDateThenReturnTrue()
        {
            // Arrange
            var architect = new Architect(1,4000,"Christian","Jones", new System.DateTime(2018,10,30), new DateTime(2018,10,30));
            //Act
            var result = architect.IsActive(architect.StartDate,architect.EndDate);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenIsActiveWhenStartDateBiggerThanEndDateThenReturnFalse()
        {
            // Arrange
            var architect = new Architect(1,4000,"Christian","Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = architect.IsActive(architect.StartDate,architect.EndDate);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenFirstNameIsNullThenThrowException()
        {
            // Arrange
            var architect = new Architect(1,4000,null,"Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = architect.GetFullName(architect.FirstName,architect.LastName);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GiventGetFullNameWhenLastNameIsNullThenThrowException()
        {
            // Arrange
            var architect = new Architect(1,4000,"Christian",null,new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = architect.GetFullName(architect.FirstName,architect.LastName);
            //Assert
        }

        [TestMethod]
        public void GiventGetFullNameWhenBothAreValidThenReturnFullName()
        {
            //Arrange
            var architect = new Architect(1,4000,"Christian","Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            //Act
            var result = architect.GetFullName("Christian","Jones");
            //Assert
            Assert.AreEqual(result,"Christian Jones");
        }

        [TestMethod]
        public void TestSalutationValidArguments()
        {
            var architect = new Architect(1,4000,"Christian","Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            String result = architect.Salutation(architect.GetFullName(architect.FirstName,architect.LastName));
            Assert.IsTrue(result == "Hello architect Christian Jones");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestSalutationInvalidFirstName()
        {
            var architect = new Architect(1,4000,null,"Jones",new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            String result = architect.Salutation(architect.GetFullName(null, "Jones"));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestSalutationInvalidLastName()
        {
            var architect = new Architect(1,4000,"Christian",null,new System.DateTime(2018,09,30), new System.DateTime(2018,09,29));
            String result = architect.Salutation(architect.GetFullName("Christian", null));
        }
    }
}
