using AutoFixture;
using FluentAssertions;
using NSubstitute;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.Models;
using ToolsBazaar.Web.Services;
using ToolsBazaar.Web.Services.Abstractions;

namespace ToolsBazaar.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly ICustomerService _sut;
        private readonly ICustomerRepository _mockCustomerRepository;

        public CustomerServiceTests()
        {
            _mockCustomerRepository = Substitute.For<ICustomerRepository>();
            _sut = new CustomerService(_mockCustomerRepository);     
        }

        [Fact]
        public void ShouldGetAll()
        {
            var customers = new Fixture().Build<Customer>().CreateMany();
            // Arrange
            _mockCustomerRepository.GetAll().Returns(customers);

            // Act
            var data = _sut.GetAll();

            // Assert
            data.Should().BeEquivalentTo(customers);
            _mockCustomerRepository.Received().GetAll();
        }

        [Fact]
        public void ShouldGetSomeDataAndAddRule()
        {
            var from = DateTime.Now;
            var to = DateTime.Now.AddMonths(3);
            var count = 5;
            var topNCustomers = new Fixture().Build<TopNCustomersBetween>()
                .CreateMany();
            // Arrange
            _mockCustomerRepository.GetTopBetween(from, to).Returns(topNCustomers);

            // Act
            var data = _sut.GetTopNCustomersBetween(from, to, count);

            // Assert
            data.Should().BeEquivalentTo(topNCustomers);
            _mockCustomerRepository.Received().GetTopBetween(Arg.Is<DateTime>(p => p.Equals(from)), Arg.Is<DateTime>(p => p.Equals(to)));
        }

    }
}
