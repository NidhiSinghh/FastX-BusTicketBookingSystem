using FastX.Models;

namespace FastX.Interfaces
{
    public interface ISeatService
    {
        public Task<Seat> AddSeat(Seat seat);
        public Task<List<Seat>> GetSeatList();
        public Task<Seat> GetSeat(int id);
        public Task<Seat> DeleteSeat(int id);
    }
}
