using Api.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public Product Test()
        {
            return new Product()
            {
                ActiveFrom = DateTime.UtcNow,
                Description = "fak",
                Id = 1,
                Name = "name",
                Price = 204.20,
            };
        }
    }
}
