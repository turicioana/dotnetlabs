using System;

namespace Architect.Data
{
     public abstract class Employee
    {
        public abstract string GetFullName(string firstName, string lastName);
        public abstract Boolean IsActive(DateTime startDate, DateTime endDate);        
    }
    public class Architect : Employee
    {
         public int Id{set;get;}
        public string FirstName{set;get;}

        public string LastName{set;get;}

        public DateTime StartDate{set;get;}

        public DateTime EndDate{set;get;}

        public double Salary{get;set;}

        public override string GetFullName(string firstName, string lastName){
            if(firstName ==null || lastName==null){
                throw new ArgumentNullException("FirstName/LastName should not be null");
            }
            return firstName +" " + lastName;
        }

        public override Boolean IsActive(DateTime startDate, DateTime endDate){
            if(startDate<=endDate)
            {
                return true;
            }
            return false;
        }
    }
}
