using FluentAssertions;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Persistence;

namespace ToolsBazaar.Tests.Repository
{
    public class CustomerRepositoryTests
    {
        private readonly ICustomerRepository _sut;

        public CustomerRepositoryTests()
        {
            _sut = new CustomerRepository();
        }

        [Fact]
        public void ShouldThrowExceptionWhenFromGreaterThanTo()
        {
            // Arrange
            var from = DateTime.UtcNow.AddDays(10);
            var to = DateTime.UtcNow;

            // Act
            var top = () => _sut.GetTopBetween(from, to);

            // Assert
            top.Should().Throw<Exception>();
        }

        [Fact]
        public void ShouldAggregateForValidData()
        {
            // Arrange
            var from = new DateTime(2005, 01, 01);
            var to = new DateTime(2023, 01, 01);

            // Act
            var top5Aggregated = _sut.GetTopBetween(from, to);

            // Assert
            top5Aggregated.Should().NotBeNull();
        }
    }
}
