using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.ProductAggregate;
using ToolsBazaar.Persistence;
using ToolsBazaar.Web.Services;
using ToolsBazaar.Web.Services.Abstractions;

namespace ToolsBazaar.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection container)
        {
            container.AddScoped<IProductRepository, ProductRepository>();
            container.AddScoped<ICustomerRepository, CustomerRepository>();
            container.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
