
namespace PocoPanel.Application.DTOs.Factors
{
    public class GetOrderViewModel
    {
        public int order { get; set; }
        public string status { get; set; }
        public decimal charge { get; set; }
        public int start_count { get; set; }
        public int remains { get; set; }
    }
}
