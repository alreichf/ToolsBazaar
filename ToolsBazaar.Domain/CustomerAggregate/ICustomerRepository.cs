using ToolsBazaar.Domain.Models;

namespace ToolsBazaar.Domain.CustomerAggregate;

public interface ICustomerRepository
{
    bool UpdateCustomerName(int customerId, string name);
    IEnumerable<Customer> GetAll();

    IEnumerable<TopNCustomersBetween> GetTopBetween(DateTime from, DateTime to);
}