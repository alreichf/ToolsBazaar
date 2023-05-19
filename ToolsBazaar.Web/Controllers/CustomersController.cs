using Microsoft.AspNetCore.Mvc;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Web.Services.Abstractions;
using ToolsBazaar.Web.ViewModels;

namespace ToolsBazaar.Web.Controllers;

public record CustomerDto(string Name);

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpPut("{customerId:int}")]
    public IActionResult UpdateCustomerName([FromRoute] int customerId, [FromBody]  CustomerDto dto)
    {
        _logger.LogInformation($"Updating customer #{customerId} name...");

        if ( !_customerService.UpdateCustomerName(customerId, dto.Name))
        {
            _logger.LogWarning($"No Matching customer found for customer with ID:  {customerId}");
            return NotFound();
        }

        return Ok();
    }

    [HttpGet()]
    [Route("top")]
    public IActionResult GetTopN([FromQuery] ApiQuery query)
    {
        _logger.LogInformation($"Getting Top {query.Count} Customer that bought the most between {query.From} and {query.To}...");

        return Ok(_customerService.GetTopNCustomersBetween(query.From, query.To, query.Count));
    }
}