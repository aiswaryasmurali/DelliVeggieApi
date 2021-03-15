using Product.Messages.Models;
using Product.Subscriber.Repository;
using Product.Subscriber.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Product.Subscriber.DataLayer.Entities;

namespace Product.Subscriber.Services
{
    public class ProductService
    {
        public static IProductRepository _repo;
        public ProductService()
        {
            _repo = new ProductRepository();
        }
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        public List<ProductResponse> GetProducts()
        {         

            var productList1 = new List<ProductResponse>();
            productList1 = _repo.Get();
            return productList1;
        }
        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductResponse GetProduct(string productId)
        {
            var product = _repo.Get(productId) ;
            return new ProductResponse { Id = product.Id, ProductName = product.ProductName, EntryDate = product.EntryDate, Price = product.Price, Product_Id = product.Product_Id };
        }
    }
}
