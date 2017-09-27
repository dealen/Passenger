using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;

        public DriverService(IMapper mapper, IDriverRepository driverRepository)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
        }

        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if (driver == null)
                throw new Exception($"Driver with privided Id:{userId} does not exist.");
            return _mapper.Map<DriverDto>(driver);
        }

        public async Task RegisterDriverAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}