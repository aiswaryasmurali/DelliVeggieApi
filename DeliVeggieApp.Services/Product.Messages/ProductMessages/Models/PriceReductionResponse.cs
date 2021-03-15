namespace Product.Messages.Models
{
    public class PriceReductionResponse
    {
        public string Id { get; set; }
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}
