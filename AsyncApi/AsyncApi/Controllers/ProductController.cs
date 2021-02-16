using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncApi.Repositories;
using AsyncApi.Models;

namespace AsyncApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product != null)
            {
                await productRepository.AddProduct(product);
                return NoContent();
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            Product product = await productRepository.GetProduct(id);
            if (product != null)
            {
                return new OkObjectResult(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> Getproducts()
        {
            IEnumerable<Product> products = await productRepository.GetProducts();

            if (products != null)
            {
                return new OkObjectResult(products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            if (await productRepository.GetProduct(id) != null)
            {
                await productRepository.DeleteProduct(id);
                return NoContent();

            }
            else
            {
                return NotFound();
            }

        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product proudct)
        {
            if (proudct != null)
            {
                await productRepository.UpdateProduct(proudct);
                return NoContent();
            }
            else
            {
                return UnprocessableEntity();
            }
        }

    }
}
