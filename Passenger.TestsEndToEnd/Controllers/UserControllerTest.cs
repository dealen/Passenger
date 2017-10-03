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
using Passenger.Infrastructure.DTO;
using Xunit;

namespace Passenger.TestsEndToEnd.Controllers
{
    public class UserControllerTest : ControllerTestsBase
    {        
        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            // Act
            var email = "test1@email.com";
            var response = await Client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            // Assert
            user.Email.Should().Be(email);
        }


        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            // Act
            var email = "test11111@email.com";
            var response = await Client.GetAsync($"users/{email}");
            
            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            // act
            var request = new CreateUser() {
                Email = "test6@email.com", Username = "test", Password = "secret", Role = "user"
            };
            var payload = GetPayload(request);

            var response = await Client.PostAsync($"users", payload);
            
            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Email}");
        }

        private async Task<UserDto> GetUserAsync(string email)
        {

            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
/*
test1@email.com
test1@email.com
 */