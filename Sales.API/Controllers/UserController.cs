﻿using Microsoft.AspNetCore.Mvc;
using Sales.API.Application.Services;
using Sales.API.Domain.DTOs.Comission;
using Sales.API.Domain.DTOs.User;
using Sales.API.Domain.Interfaces.Services;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateAsync(userDTO);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> Login([FromQuery] string username, string password)
        {
            var result = _userService.Login(username, password);
            if (result == true)
                return Ok(result);

            return BadRequest();
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }
        
        [HttpPut("UpdateUserNameById/{id}")]
        public async Task<IActionResult> UpdateUserNameById(Guid id, string userName)
        {
            var result = await _userService.UpdateUserNameById(id, userName);
            return Ok(result);
        }
    }
}
