using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 12000 },
            new Product { Id = 2, Name = "Mouse", Price = 300 },
            new Product { Id = 3, Name = "Teclado", Price = 450 }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            newProduct.Id = products.Count + 1;
            products.Add(newProduct);
            return Ok(newProduct);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}

