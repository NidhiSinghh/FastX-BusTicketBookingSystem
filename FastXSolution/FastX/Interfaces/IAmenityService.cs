using FastX.Models;
using FastX.Models.Dto;

namespace FastX.Interfaces
{
    public interface IAmenityService
    {
        public Task<List<AmenityDto>> GetBusAmenitiesAsync(int busId);
    }
}
 