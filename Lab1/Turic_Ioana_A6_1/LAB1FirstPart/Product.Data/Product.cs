using System;

namespace Product.Data
{
    public class Product
    {
        public int Id {get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public DateTime StartDate{get;set;}
        public DateTime EndDate{get;set;}
        public int Price{get;set;}
        public double VAT;

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
