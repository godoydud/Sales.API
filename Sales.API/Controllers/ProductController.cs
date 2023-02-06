using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.API.Domain.DTOs;
using Sales.API.Domain.Interfaces.Services;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {

            if (ModelState.IsValid)
            {
                var result = await _productService.CreateAsync(productDTO);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.GetAllAsync();
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.GetByIdAsync(id);
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _productService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.UpdateAsync(productDTO);
            if (ModelState.IsValid)
                return StatusCode(StatusCodes.Status200OK);

            return BadRequest(result);
        }

    }
}
