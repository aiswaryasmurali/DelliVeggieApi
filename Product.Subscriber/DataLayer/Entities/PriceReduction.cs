using MongoDB.Bson.Serialization.Attributes;

namespace Product.Subscriber.DataLayer.Entities
{
    public class PriceReduction
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}
