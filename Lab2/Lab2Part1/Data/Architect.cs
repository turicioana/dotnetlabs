using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Architect : Employee
    {

        public Architect(int id, int salary, string firstName, string lastName, DateTime startDate, DateTime endDate) : base(id, salary,firstName, lastName,startDate,endDate)
        {

        }
        public override String Salutation(String fullName)
        {
            return "Hello architect " + fullName;
        }
    }
}