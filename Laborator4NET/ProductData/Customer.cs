using System;
using System.ComponentModel.DataAnnotations;

namespace ProductData
{
    public class Customer
    {
        private Customer()
        {

        }

        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Adress { set; get; }

        [RegularExpression("@+40+0\\d{9}$",ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { set; get; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { set; get; }

        public Customer(Guid id,string name, string adress, string phoneNumber, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
    }
}
