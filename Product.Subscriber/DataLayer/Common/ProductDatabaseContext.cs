namespace Product.Subscriber.DataLayer.Common
{
    public class ProductDatabaseContext
    {
        public string ProductCollectionName { get; set; }
        public string ReductionCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
