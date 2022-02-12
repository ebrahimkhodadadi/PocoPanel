namespace PocoPanel.Application.DTOs.Factors
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotallPrice { get; set; }
        public string SocialUserName { get; set; }
        public int Quantity { get; set; }
        public string ProductName  {get; set; }
        public string Status { get; set; }
        public string PriceKind { get; set;}
    }
}