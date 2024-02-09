using FastX.Contexts;
using FastX.Interfaces;
using FastX.Models;
using Microsoft.EntityFrameworkCore;

namespace FastX.Repositories
{
    public class SeatRepository : IRepository<int, Seat>
    {
        private readonly FastXContext _context;

        public SeatRepository(FastXContext context)
        {
            _context = context;
        }
        public Task<Seat> Add(Seat item)
        {
            throw new NotImplementedException();
        }

        public Task<Seat> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Seat>> GetAsync()
        {
            var seats = await _context.Seats.ToListAsync();
            return seats;
        }

        public Task<Seat> GetAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Seat> Update(Seat item)
        {
            throw new NotImplementedException();
        }
    }
}
