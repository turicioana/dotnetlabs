using System;

namespace Manager.Data
{
    public class Manager
    {
        public int Id{set;get;}
        public string FirstName{set;get;}

        public string LastName{set;get;}

        public DateTime StartDate{set;get;}

        public DateTime EndDate{set;get;}

        public double Salary{get;set;}

        public string GetFullName(string firstName, string lastName){
            if(firstName ==null || lastName==null){
                throw new ArgumentNullException("FirstName/LastName should not be null");
            }
            return firstName + " " + lastName;
        }

        public Boolean IsActive(DateTime startDate, DateTime endDate){
            if(startDate<=DateTime.Now && endDate > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
