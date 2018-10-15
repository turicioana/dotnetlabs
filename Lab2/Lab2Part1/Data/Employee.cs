using System;
using System.Collections.Generic;

namespace Data
{
    public abstract class Employee
    {
        public int Id { get; private set; }
        public int Salary { get; private set; }
        public String FirstName  { get; private set; }
        public String LastName  { get; private set; }
        public DateTime StartDate  { get; private set; } 
        public DateTime EndDate  { get; private set; }

        public Employee(int id, int salary, string firstName, string lastName, DateTime startDate, DateTime endDate)
        {
            this.Id = id;
            this.Salary = salary;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public String GetFullName(String firstName, String lastName)
        {
            if (firstName == null || lastName == null)
                throw new ArgumentNullException("FirstName/LastName should be valid");
            else
                return firstName + ' ' + lastName;
        }

        public bool IsActive(DateTime startDate, DateTime endDate)
        {
            int result = DateTime.Compare(startDate, endDate);
            return (result > 0) ? false : true;
        }
        public abstract String Salutation(String fullName);
    }
}
