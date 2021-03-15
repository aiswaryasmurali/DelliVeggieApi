using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Messages.Models;
using Product.Subscriber.Services;
using System.Collections.Generic;
using Xunit;

namespace Product.UnitTests
{
    [TestClass]
    public class ProductServiceTest
    {
        readonly ProductService productServices = new ProductService();
        List<ProductResponse> product = new List<ProductResponse>();
        [Fact]
        public void GetProduct()
        {
            Assert.IsNotNull(productServices.GetProducts());


        }
        [Fact]
        public void GetProductDetails()
        {

            Assert.IsNotNull(productServices.GetProduct("_id6044f728a41aa4653838ede6"));

        }
    }
}
