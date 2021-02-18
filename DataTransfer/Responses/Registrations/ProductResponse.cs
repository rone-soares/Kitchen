namespace DataTransfer.Responses.Registrations
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TimeToFinish { get; set; }
        public KitchenAreaResponse KitchenArea { get; set; }
    }
}
