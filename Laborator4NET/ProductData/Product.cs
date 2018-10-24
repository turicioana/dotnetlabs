using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace ProductData
{
    public class Product
    {
        private Product()
        {

        }

        public Guid Id { set; get; }

        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        public string Description { set; get; }

        [Required]
        public DateTime StartDate { set; get; }

        public DateTime? EndDate { set; get; }

        [Required]
        public int Price { set; get; }

        [Required]
        public int VAT { set; get; }

        public Product(Guid id, string name, string description, DateTime startDate, DateTime endDate, int price)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            VAT = ComputeVAT(price);
        }

        public bool IsValid(DateTime startDate, DateTime endDate)
        {
            if (startDate <= endDate)
            {
                return true;
            }
            return false;
        }

        public int ComputeVAT(int price)
        {
            if (price < 100)
            {
                return this.VAT = (price * 9) / 100;
            }
            return this.VAT = (price * 14) / 100;
        }
    }
}
