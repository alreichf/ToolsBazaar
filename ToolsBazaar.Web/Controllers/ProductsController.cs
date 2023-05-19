using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToolsBazaar.Domain.CustomerAggregate;
using ToolsBazaar.Domain.ProductAggregate;
using ToolsBazaar.Persistence;

namespace ToolsBazaar.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase 
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepositor)
    {
        _logger = logger;
        _productRepository = productRepositor;
    }

    [HttpGet]
    [Route("most-expensive")]
    public ActionResult<IEnumerable<Product>> MostExpensive()
    {
        _logger.LogInformation($"Getting Most expensive sorted by name...");

        return Ok(_productRepository.GetAllSortedByMostExpensive());
    }
}