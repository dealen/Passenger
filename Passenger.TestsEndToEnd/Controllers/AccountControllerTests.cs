using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Xunit;

namespace Passenger.TestsEndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {        
        [Fact]
        protected async Task given_valid_current_and_new_password_id_should_be_changed()
        {
            // act
            var command = new ChangeUserPassword() {
                CurrentPassword = "secret",
                NewPassword = "secret1"
            };
            var payload = GetPayload(command);

            var response = await Client.PutAsync($"account/password", payload);
            
            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}