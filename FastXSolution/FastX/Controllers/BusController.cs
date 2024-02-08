using FastX.Exceptions;
using FastX.Interfaces;
using FastX.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        [HttpGet("search")]
     
        public async Task<ActionResult<List<BusDto>>> SearchBusesAsync(string origin, string destination, DateTime date)
        {
            try
            {
                var busDtos = await _busService.SearchBusesAsync(origin, destination, date);
                return Ok(busDtos);
            }
            catch (BusNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("searchWithBusType")]

        public async Task<ActionResult<List<BusDto>>> SearchBusesAsync(string origin, string destination, DateTime date,string busType)
        {
            try
            {
                var busDtos = await _busService.SearchBusesAsync(origin, destination, date,busType);
                return Ok(busDtos);
            }
            catch (BusNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

       

    }
}

