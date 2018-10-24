using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductData
{
    public class ProductRepository
    {
        private readonly ProductManagement _context;

        public ProductRepository()
        {
            this._context = new ProductManagement();
        }

        public void CreateProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            var existingProduct = this._context.Products.First(t => t.Id == product.Id);
            existingProduct.Description = product.Description;
            existingProduct.Name = product.Name;
            existingProduct.StartDate = product.StartDate;
            existingProduct.EndDate = product.EndDate;
            existingProduct.Price = product.Price;
            existingProduct.VAT = product.VAT;
            _context.SaveChanges();
        }

        public Product GetProductById(Guid id)
        {
            return this._context.Products.First(t => t.Id == id);
        }

        public void DeleteProduct(Product product)
        {
            var deletedProduct = this._context.Products.First(t => t.Id == product.Id);
            _context.Products.Remove(deletedProduct);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this._context.Products;
        }

        public IEnumerable<Product> GetProductsByPrice(int price)
        {
            return this._context.Products.Where(product => product.Price == price);
        }
    }
}
