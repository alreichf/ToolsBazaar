using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.Models;

namespace ToolsBazaar.Web.Services.Abstractions
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();

        IEnumerable<TopNCustomersBetween> GetTopNCustomersBetween(DateTime from, DateTime to, int? count = 5);

        bool UpdateCustomerName(int customerId, string name);

    }
}
