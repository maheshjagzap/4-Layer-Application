using ApplicationLayer.Services;
using CoreLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_productService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // this comment for test git push
        // this comment for test git push 2
        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            _productService.Add(product);
            return Ok("Product added successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            product.Id = id;
            _productService.Update(product);
            return Ok("Product updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok("Product deleted successfully");
        }
    }
}
