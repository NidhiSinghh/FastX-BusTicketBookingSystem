using FastX.Contexts;
using FastX.Exceptions;
using FastX.Interfaces;
using FastX.Models;
using FastX.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace FastX.Services
{
    public class AmenityService : IAmenityService
    {
        private readonly IBusRepository _busRepository;
        private readonly ILogger<BusService> _logger;
        private readonly FastXContext _context;

        public AmenityService(IBusRepository busRepository, ILogger<BusService> logger,FastXContext context)
        {
            _busRepository = busRepository;
            _logger = logger;
            _context = context;
        }

        public async Task<List<AmenityDto>> GetBusAmenitiesAsync(int busId)
        {
            try
            {
                _logger.LogInformation($"Fetching amenities for Bus ID: {busId}");

                // Call the repository method to retrieve the bus by ID
                //var bus = await _busRepository.GetAsync(busId);
                var bus = await _context.Buses
            .Include(b => b.BusAmenities)
            .ThenInclude(ba => ba.Amenity)
            .FirstOrDefaultAsync(b => b.BusId == busId);

                if (bus == null)
                {
                    _logger.LogWarning($"Bus not found for ID: {busId}");
                    throw new BusNotFoundException();
                }

                // Access the bus's amenities and select AmenityId and Name
                //    var amenities = bus.BusAmenities
                //.Select(ba => ba.Amenity)
                //.ToList();
                var amenities = bus.BusAmenities
                .Select(ba => new AmenityDto
                {
                    AmenityId = ba.Amenity.AmenityId,
                    Name = ba.Amenity.Name
                })
                .ToList();


                if (amenities == null || !amenities.Any())
                {
                    _logger.LogWarning($"No amenities found for Bus ID: {busId}");
                    throw new AmenitiesNotFoundException();
                }

                _logger.LogInformation($"Amenities fetched successfully for Bus ID: {busId}");

                return amenities;
            }
            catch (BusNotFoundException)
            {
                // Rethrow the exception if the bus is not found
                throw;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                _logger.LogError($"An error occurred: {ex}");
                throw new Exception("An error occurred while processing your request.");
            }
        }


    }
}
