using System;
using System.Collections.Generic;

namespace Product.Data
{
    public class ProductRepository
    {
        private List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            _products.Add(new Product(10,"Chocolate", "very good",new DateTime(2018,10,03), new DateTime(2018,10,10),5));
            _products.Add(new Product(11,"Butter", "very good",new DateTime(2018,09,03), new DateTime(2018,10,10),6));
            _products.Add(new Product(12,"Thing", "very good",new DateTime(2018,10,03), new DateTime(2018,10,10),10));
            _products.Add(new Product(13,"Smth", "very good",new DateTime(2018,10,03), new DateTime(2018,10,10),100));
        }

        public int Capacity()
        {
            return _products.Count;
        }

        public object GetProductByName(string productName)
        {
            if(productName == null)
            {
                throw new ArgumentNullException("Product name is NULL");
            }
            else
            {
                foreach(Product product in _products)
                {
                    if(product.Name == productName)
                        return product;
                }            
            }
            return false;
        }

        public void AddProduct(Product product)
        {
            if(product == null || !product.IsValid(product.StartDate, product.EndDate))
            {
                throw new ArgumentNullException("Product should be valid");
            } 
            else
            {
                _products.Add(product);
            }
        }

        public void RemoveProductByName(string productName)
        {
            if (productName == null)
            {
                throw new ArgumentNullException("Product name should be valid");
            }
            else
            {
                foreach(Product product in _products)
                {
                    if(product.Name == productName)
                    {
                        _products.Remove(product);
                    }
                }
            }
        }

        public object FindAllProducts()
        {
            foreach(Product product in _products)
            {
                return product;
            }
            return 0;
        }

        public object GetProductByPosition(int position)
        {
            if (position<0 || position>=_products.Count)
            {
                throw new IndexOutOfRangeException("Not a valid position");
            }
            return _products[position];
        }
        
    }
}