using System;

namespace Product.Messages.Models
{
    public class ProductResponse
    {
       
        public string Id { get; set; }
        public int Product_Id { get; set; }       
        public string ProductName { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
    }
}
