
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Product.Messages.Commands;
using Product.Messages.Events;
using Product.Messages.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public HttpResponseMessage Post([FromBody] ProductResponse product)
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost;timeout=60");
            messageBus.Publish(product);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        /// <summary>
        /// Get All Products 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductResponse> Get()
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost;timeout=60");
            List<ProductResponse> _productlist = new List<ProductResponse>();
            var response = messageBus.Request<ProductsCommand, ProductsEvent>(new ProductsCommand
            {
                Records = 5
            });

            foreach (ProductResponse objProduct in response.ProductList)
            {

                _productlist.Add(objProduct);
            }

            return _productlist;
        }
        /// <summary>
        /// Get Products by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public ProductResponse Get(string id)
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost;timeout=60");

            var response = messageBus.Request<ProductsCommand, ProductsEvent>(new ProductsCommand
            {
                Records = 5,
                Param = id
            });

            return response.Product;
        }

    }
}
