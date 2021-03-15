using EasyNetQ;
using Product.Messages.Commands;
using Product.Messages.Events;
using Product.Messages.Models;
using Product.Subscriber.Services;
using System;
using System.Linq;

namespace Product.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService _productService = new ProductService();
            var messageBus = RabbitHutch.CreateBus("host=localhost;timeout=60");
            messageBus.Subscribe<ProductResponse>("SubscriptionId", msg => {
                Console.WriteLine($"Product :{msg.ProductName} costs {msg.Price}");
            });

            messageBus.Respond<ProductsCommand, ProductsEvent>(request => {
                return !string.IsNullOrWhiteSpace(request.Param) ? new ProductsEvent
                {

                    Product = _productService.GetProduct(request.Param)


                } : new ProductsEvent
                {
                    ProductList = _productService.GetProducts().Take(request.Records).ToList()
                   

                };
            });

        }
    }
}
