using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();

            var userService = new UserService(userRepository.Object, mapper.Object);
            await userService.RegisterAsync("user34@email.com", "userrr", "admin", "secret");

            userRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}