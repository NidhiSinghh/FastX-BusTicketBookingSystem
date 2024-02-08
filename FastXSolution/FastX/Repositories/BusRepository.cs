using FastX.Contexts;
using FastX.Exceptions;
using FastX.Interfaces;
using FastX.Models;
using Microsoft.EntityFrameworkCore;

namespace FastX.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly FastXContext _context;

        public BusRepository(FastXContext context)
        {
            _context = context;
        }
        public async Task<List<Bus>> GetBusesByCriteriaAsync(string origin, string destination, DateTime date)
        {
            // Perform the database query to get buses based on origin, destination, and date
            return await _context.Buses
                .Where(b => b.Origin == origin && b.Destination == destination)
                // Add additional conditions based on your database schema
                .ToListAsync();
        }

        public async Task<List<Bus>> GetBusesByCriteriaAsyncWithBusType(string origin, string destination, DateTime date, string busType)
        {
            var buses= await _context.Buses
                .Where(b => b.Origin == origin && b.Destination == destination&&b.BusType==busType).ToListAsync();
            return buses;
        }

        public async Task<Bus> GetAsync(int key)
        {
            var buses = await GetAsync();
            var bus = await _context.Buses
        .Include(b => b.BusAmenities)
        .FirstOrDefaultAsync(e => e.BusId == key);

            if (bus != null)
                return bus;
            throw new BusNotFoundException();
        }
        public async Task<List<Bus>> GetAsync()
        {
            var buses = await _context.Buses.ToListAsync();
            return buses;
        }

    }
}
