using MongoDB.Driver;
using Product.Subscriber.Repository.Interfaces;
using System;
using System.Collections.Generic;
using Product.Subscriber.DataLayer.Entities;
using Product.Subscriber.DataLayer.Common;
using Product.Messages.Models;

namespace Product.Subscriber.Repository
{
    public  class ProductRepository: IProductRepository
    {
        private readonly IMongoCollection<Products> _products;
        private readonly IMongoCollection<PriceReduction> _reductions;
        ProductDatabaseContext _databaseSettings;
        public ProductRepository()
        {
            SetDbConnection();
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _products = database.GetCollection<Products>(_databaseSettings.ProductCollectionName);
            _reductions = database.GetCollection<PriceReduction>(_databaseSettings.ReductionCollectionName);

        }

        //we can read this from config file
        private void SetDbConnection()
        {
            _databaseSettings = new ProductDatabaseContext();
            _databaseSettings.ConnectionString = "mongodb://localhost:27017";
            _databaseSettings.DatabaseName = "productdb";
            _databaseSettings.ProductCollectionName = "Products";
            _databaseSettings.ReductionCollectionName = "PriceReductions";

        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public List<ProductResponse> Get()
        {
            List<Products> products;
            products = _products.Find(prod => true).ToList();
            List<ProductResponse> productresponselist=new List<ProductResponse>();
            ProductResponse productresponce;
            for (int i = 0; i < products.Count; i++)
            {
                productresponce = new ProductResponse();
                productresponce.Id = products[i].Id;
                productresponce.Product_Id = products[i].Product_Id;
                productresponce.ProductName = products[i].ProductName;
                productresponce.Price = products[i].Price;
                productresponselist.Add(productresponce);
            }
            return productresponselist;
        }

        /// <summary>
        /// Get Product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductResponse Get(string id)
        {
            Products currentproduct = new Products();
            PriceReduction currentreduction = new PriceReduction();
            currentproduct = _products.Find<Products>(prod => prod.Id == id).FirstOrDefault();
            int currentday = (int)Enum.Parse(typeof(Days), Convert.ToString(DateTime.Today.DayOfWeek));
            if (currentday != -1)
            {
                currentreduction = _reductions.Find<PriceReduction>(reduction => reduction.DayOfWeek == currentday).FirstOrDefault();
                if (currentreduction != null)
                {
                    currentproduct.Price = currentproduct.Price - currentreduction.Reduction;
                }
            }
            ProductResponse responce = new ProductResponse();
            responce.Id = currentproduct.Id;
            responce.Product_Id = currentproduct.Product_Id;
            responce.ProductName = currentproduct.ProductName;
            responce.Price = currentproduct.Price;


            return responce;
        }

        enum Days
        {
            Sunday=0,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday

        }        
    }
}
