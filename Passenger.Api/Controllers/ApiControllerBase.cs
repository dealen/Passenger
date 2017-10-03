using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher _commandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
    }
}