using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto GetDto(string email);
        void Register(string email, string password, string username);
    }
}