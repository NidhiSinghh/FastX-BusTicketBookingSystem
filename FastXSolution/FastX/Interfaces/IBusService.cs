using FastX.Models;

namespace FastX.Interfaces
{
    public interface IBusService
    {
        public Task<List<Bus>> GetBusList();
        public Task<Bus> GetBus(int id);
        Task<List<BusDto>> SearchBusesAsync(string origin, string destination, DateTime date);
        Task<List<BusDto>> SearchBusesAsync(string origin, string destination, DateTime date,string busType);

       
    }
}
