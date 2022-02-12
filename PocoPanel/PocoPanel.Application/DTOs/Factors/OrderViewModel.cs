

using PocoPanel.Application.DTOs.Factors.Common;

namespace PocoPanel.Application.DTOs.Factors
{
    public class OrderViewModel : BaseProvider
    {
        public int? serviceId { get; set; }
        public string link { get; set; }
        public int quantity { get; set; }
        public int runs { get; set; }
        public int interval { get; set; }
    }
}
