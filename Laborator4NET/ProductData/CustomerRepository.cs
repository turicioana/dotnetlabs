using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductData
{
    public class CustomerRepository
    {
        
        private readonly ProductManagement _context;

        public CustomerRepository()
        {
            this._context = new ProductManagement();
        }

        public void CreateCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            var existingCustomer = this._context.Customers.First(t => t.Id == customer.Id);
            existingCustomer.Name = customer.Name;
            existingCustomer.Adress = customer.Adress;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Email = customer.Email;
            _context.SaveChanges();
        }

        public Customer GetCustomerById(Guid id)
        {
            return this._context.Customers.First(t => t.Id == id);
        }
        
        public void DeleteCustomer(Customer customer)
        {
            var deletedCustomer = this._context.Customers.First(t => t.Id == customer.Id);
            _context.Customers.Remove(deletedCustomer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this._context.Customers;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return this._context.Customers.Where(product => product.Email == email).First();
        }
    }
}
