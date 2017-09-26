using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET /users/5
        [HttpGet("{email}")]
        public async Task<UserDto> GetAsync(string email)
            => await _userService.GetAsync(email);

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Json(users);
        }

        //[HttpPost("")] to lub [HttpPost]
        [HttpPost]
        public async Task Post([FromBody]CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.Password, request.Role, request.Username);
        }
    }
}
