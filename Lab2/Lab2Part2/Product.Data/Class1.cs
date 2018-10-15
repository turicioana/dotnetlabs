using System;

namespace Product.Data
{
    public class Product
    {
        public int Id {get; private set;}
        public string Name{get;private set;}
        public string Description{get;private set;}
        public DateTime StartDate{get;private set;}
        public DateTime EndDate{get;private set;}
        public int Price{get;private set;}
        public double VAT;

        public Product(int id, string name, string description, DateTime startDate, DateTime endDate, int price)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
        }

        public bool IsValid(DateTime startDate, DateTime endDate)
        {
            if(startDate<=endDate)
            {
                return true;
            }
            return false;
        }

        public double ComputeVAT(int price){
            if(price<100)
            {
            return this.VAT = (price*9)/100;
            }
            return this.VAT = (price*14)/100;
        }
    }
}
