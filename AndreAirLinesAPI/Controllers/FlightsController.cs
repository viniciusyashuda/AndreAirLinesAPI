using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesAPI.Data;
using AndreAirLinesAPI.Model;

namespace AndreAirLinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly AndreAirLinesAPIContext _context;

        public FlightsController(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlight()
        {
            return await _context.Flight.Include(flight => flight.Destination)
                                        .Include(flight => flight.Origin)
                                        .Include(flight => flight.Passenger)
                                        .Include(flight => flight.Aircraft)
                                        .ToListAsync();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _context.Flight.Include(flight => flight.Aircraft)
                                              .Include(flight => flight.Destination)
                                              .Include(flight => flight.Origin)
                                              .Include(flight => flight.Passenger)
                                              .Where(flight => flight.Id == id).SingleOrDefaultAsync();

            return flight;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            var destination = await _context.Airport.Where(airport => airport.Acronym == flight.Destination.Acronym).FirstOrDefaultAsync();
            if (destination != null)
            {
                flight.Destination = destination;
            }

            var origin = await _context.Airport.Where(airport => airport.Acronym == flight.Origin.Acronym).FirstOrDefaultAsync();
            if (origin != null)
            {
                flight.Origin = origin;
            }

            var aircraft = await _context.Aircraft.Where(aircraft => aircraft.Id == flight.Aircraft.Id).FirstOrDefaultAsync();
            if (aircraft != null)
            {
                flight.Aircraft = aircraft;
            }

            var passenger = await _context.Passenger.Where(passenger => passenger.Cpf == flight.Passenger.Cpf).FirstOrDefaultAsync();
            if (passenger != null)
            {
                flight.Passenger = passenger;
            }


            _context.Flight.Add(flight);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightExists(flight.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}
