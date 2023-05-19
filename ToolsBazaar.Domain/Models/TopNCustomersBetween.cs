using ToolsBazaar.Domain.CustomerAggregate;

namespace ToolsBazaar.Domain.Models
{
    public class TopNCustomersBetween
    {
        public Customer Customer { get; set; }
        public decimal Spend { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}