using Microsoft.AspNetCore.Mvc;
using Sales.API.Application.Services;
using Sales.API.Domain.DTOs;
using Sales.API.Domain.Interfaces.Services;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComissionController : ControllerBase
    {
        private readonly IComissionService _comissionService;

        public ComissionController(IComissionService comissionService)
        {
            _comissionService = comissionService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ComissionDTO comissionDTO)
        {

            if (ModelState.IsValid)
            {
                var result = await _comissionService.CreateAsync(comissionDTO);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _comissionService.GetAllAsync();
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
                var result = await _comissionService.GetByIdAsync(id);
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _comissionService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ComissionDTO comissionDTO)
        {
            var result = await _comissionService.UpdateAsync(comissionDTO);
            if (ModelState.IsValid)
                return StatusCode(StatusCodes.Status200OK);

            return BadRequest(result);
        }
    }
}
