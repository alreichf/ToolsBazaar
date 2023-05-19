using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.Models;
using ToolsBazaar.Web.Services.Abstractions;

namespace ToolsBazaar.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public IEnumerable<TopNCustomersBetween> GetTopNCustomersBetween(DateTime from, DateTime to, int? count = 5)
        {
            if (from > to)
            {
                throw new Exception($"From {from} should be less than To {to}");
            }

            return _customerRepository.GetTopBetween(from, to)
                .OrderByDescending(d => d.Spend)
                .Take(count.HasValue ? count.Value : 5);
        }

        public bool UpdateCustomerName(int customerId, string name)
        {
            return _customerRepository.UpdateCustomerName(customerId, name);
        }
    }
}
