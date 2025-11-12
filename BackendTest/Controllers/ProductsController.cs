using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop HP", Price = 12000 },
            new Product { Id = 2, Name = "Mouse", Price = 300 },
            new Product { Id = 3, Name = "Teclado", Price = 450 }
        };

        [HttpGet]
        public IActionResult GetAll() => Ok(products);

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updated)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return Ok();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

