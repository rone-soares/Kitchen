namespace DataTransfer.Requests.Registrations
{
    public class ProductRequest : RequestBase
    {
        public string Description { get; set; }
        public int TimeToFinish { get; set; }
        public int IdKitchenArea { get; set; }
    }
}
