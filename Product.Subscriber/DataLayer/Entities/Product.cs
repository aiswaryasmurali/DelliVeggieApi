using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Product.Subscriber.DataLayer.Entities
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Product_Id { get; set; }
        public string ProductName { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
    }
}
