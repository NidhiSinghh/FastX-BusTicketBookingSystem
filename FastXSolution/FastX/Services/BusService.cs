using FastX.Exceptions;
using FastX.Interfaces;
using FastX.Models;

namespace FastX.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<List<BusDto>> SearchBusesAsync(string origin, string destination, DateTime date)
        {
            try
            {

                var buses= await _busRepository.GetBusesByCriteriaAsync(origin, destination, date);
                if (buses == null || buses.Count == 0)
                {
                    throw new BusNotFoundException();
                }
            
                var busDtos = buses.Select(bus => new BusDto
                {
                    BusId = bus.BusId,
                    BusName = bus.BusName,
                    BusType = bus.BusType,
                    TotalSeats = bus.TotalSeats,
                    Origin = bus.Origin,

                    Destination = bus.Destination,
                }).ToList();

                return busDtos;

            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                // You can throw a custom exception or return a default value based on your requirements
                throw new BusNotFoundException();
            }
        }

        public async Task<List<BusDto>> SearchBusesAsync(string origin, string destination, DateTime date, string busType)
        {
            try
            {
                var buses=await _busRepository.GetBusesByCriteriaAsyncWithBusType(origin, destination, date, busType);
                if(buses==null || buses.Count == 0)
                {
                    throw new BusNotFoundException();

                }
                var busDtos = buses.Select(bus => new BusDto
                {
                    BusId = bus.BusId,
                    BusName = bus.BusName,
                    BusType = bus.BusType,
                    TotalSeats = bus.TotalSeats,
                    Origin = bus.Origin,

                    Destination = bus.Destination,
                }).ToList();

                return busDtos;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // You can throw a custom exception or return a default value based on your requirements
                throw new BusNotFoundException();
            }
        }

        public async Task<Bus> GetBus(int id)
        {
            try
            {
                var bus = await _busRepository.GetAsync(id);
                if (bus == null )
                {
                    throw new BusNotFoundException();

                }
                return bus;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                // You can throw a custom exception or return a default value based on your requirements
                throw new BusNotFoundException();

            }
            
            

        }
        public async Task<List<Bus>> GetBusList()
        {
            var Bus = await _busRepository.GetAsync();
            return Bus;
        }

        
         
       
    }
}

   