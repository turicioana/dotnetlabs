using ProductData;
using System;

namespace Executabil
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var customerRepository = new CustomerRepository();

            //Create data for Products and Customers

            var product1 = new Product(Guid.NewGuid(), 
                "Milka Chocolate",
                "Made with LOVE",
                new DateTime(2018, 09, 05),
                new DateTime(2018, 10, 30),
                5);

            var product2 = new Product(Guid.NewGuid(),
                "Black tea",
                "Very intense taste and high amount of caffeine",
                new DateTime(2018,07,28),
                new DateTime(2019,10,30),
                13);

            var customer1 = new Customer(Guid.NewGuid(),
                "Turic Ioana",
                "Str. Strada Debarcaderului no. 10B",
                "+40741566987",
                "turicioana@gmail.com");

            var customer2 = new Customer(Guid.NewGuid(),
                "Iuganu Madalina",
                "Str. General Berthelor no.16",
                "+40734567891",
                "miuganu@gmail.com");


            productRepository.CreateProduct(product1);
            productRepository.CreateProduct(product2);

            customerRepository.CreateCustomer(customer1);
            customerRepository.CreateCustomer(customer2);
            

            //Edit data in Products
            Product productToEdit =
                productRepository.GetProductById(Guid.Parse("E5556EBD-8825-4F8D-BCBE-A6E6438F3AFA"));
            productToEdit.Description = "Just a TEST";
            productRepository.EditProduct(productToEdit);

            //Edit data in Customers
            Customer customerToEdit =
                customerRepository.GetCustomerById(Guid.Parse("D20CF142-F1C9-4E27-90A5-40F6551F61C8"));
            customerToEdit.Name = "TEST NAME";
            customerRepository.EditCustomer(customerToEdit);

            //Delete from Products
            Product productToDelete =
                productRepository.GetProductById(Guid.Parse("68C4F721-A9E8-4D4C-8535-CAA61B197B27"));
            productRepository.DeleteProduct(productToDelete);

            //Delete from Customers
            Customer customerToDelete =
                customerRepository.GetCustomerById(Guid.Parse("AB2D8793-BD44-4D01-ADF3-D77B344F0153"));
            customerRepository.DeleteCustomer(customerToDelete);
        }
    }
}
