using Product.Messages.Models;
using Product.Subscriber.DataLayer.Entities;
using System.Collections.Generic;

namespace Product.Subscriber.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<ProductResponse> Get();
        ProductResponse Get(string id);
    }
}
