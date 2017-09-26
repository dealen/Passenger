using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class DriversController : Controller
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("driverId")]
        public async Task<DriverDto> GetAsync(Guid driverId)
        {
            var driver = await _driverService.GetAsync(driverId);
            return driver;
        }

        [HttpPost]
        public async Task Post([FromBody]CreateDriver request)
        {
            //await _driverService.RegisterAsync(request.Email, request.Password, request.Role, request.Username);
        }
    }
}