using Product.Messages.Models;
using System.Collections.Generic;

namespace Product.Messages.Events
{
    public class ProductsEvent
    {
        public List<ProductResponse> ProductList { get; set; }
        public ProductResponse Product { get; set; }
    }
}
