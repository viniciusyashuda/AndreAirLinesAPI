using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesAPI.Data;
using AndreAirLinesAPI.Model;
using AndreAirLinesAPI.Service;

namespace AndreAirLinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly AndreAirLinesAPIContext _context;

        public AirportsController(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Airports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirport()
        {
            return await _context.Airport.Include(airport => airport.Address).ToListAsync();
        }

        // GET: api/Airports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> GetAirport(string id)
        {
            var airport = await _context.Airport.Include(airport => airport.Address)
                                                .Where(airport => airport.Acronym == id).SingleOrDefaultAsync();

            if (airport == null)
            {
                return NotFound();
            }

            return airport;
        }

        // PUT: api/Airports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport(string id, Airport airport)
        {
            if (id != airport.Acronym)
            {
                return BadRequest();
            }

            _context.Entry(airport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(id))
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

        // POST: api/Airports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airport>> PostAirport(Airport airport)
        {

            var address = await _context.Address.Where(address => address.Id == airport.Address.Id).FirstOrDefaultAsync();

            if (address != null)
            {
                airport.Address = address;
            }
            else if (address == null)
            {
                var address_viacep = await Viacep.GetAddressViaCep(airport.Address.PostalCode);
                airport.Address = new Address(airport.Address.PostalCode, address_viacep.Street, airport.Address.Number, address_viacep.District, address_viacep.City, airport.Address.Country, address_viacep.Federative_Unit, address_viacep.Complement);

            }

            _context.Airport.Add(airport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AirportExists(airport.Acronym))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAirport", new { id = airport.Acronym }, airport);
        }

        // DELETE: api/Airports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(string id)
        {
            var airport = await _context.Airport.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }

            _context.Airport.Remove(airport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirportExists(string id)
        {
            return _context.Airport.Any(e => e.Acronym == id);
        }
    }
}
