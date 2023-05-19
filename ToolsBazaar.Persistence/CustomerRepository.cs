using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.Models;

namespace ToolsBazaar.Persistence;

public class CustomerRepository : ICustomerRepository
{
    public IEnumerable<Customer> GetAll() => DataSet.AllCustomers;

    public IEnumerable<TopNCustomersBetween> GetTopBetween(DateTime from, DateTime to)
    {
        if (from > to)
        {
            throw new Exception($"From {from} should be less than To {to}");
        }

        var ordersbetween = DataSet.AllOrders.Where(o => o.Date >= from && o.Date <= to);
        var groupByCustomer = ordersbetween.GroupBy(o => o.Customer);
        return groupByCustomer.Select(gc => new
        TopNCustomersBetween
        {
            Customer = gc.Key,
            Spend = gc.Sum(o => o.Items.Sum(i => i.Product.Price * i.Quantity)),
            From = from,
            To = to
        });
    }

    public bool UpdateCustomerName(int customerId, string name)
    {
        var customer = DataSet.AllCustomers.FirstOrDefault(c => c.Id == customerId);
        if ( customer != null )
        {
            customer.UpdateName(name);
            return true;
        }

        return false;
    }
}