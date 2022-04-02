using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesAPI.Data;
using AndreAirLinesAPI.Model.Model;
using AndreAirLinesAPI.Service;
using AndreAirLinesAPI.Model;

namespace AndreAirLinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly AndreAirLinesAPIContext _context;

        public PassengersController(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Passengers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassenger()
        {
            return await _context.Passenger.Include(passenger => passenger.Address).ToListAsync();
        }

        // GET: api/Passengers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(string id)
        {
            var passenger = await _context.Passenger.Include(passenger => passenger.Address)
                                                     .Where(passenger => passenger.Cpf == id).SingleOrDefaultAsync();

            if (passenger == null)
            {
                return NotFound();
            }

            return passenger;
        }

        // PUT: api/Passengers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(string id, Passenger passenger)
        {
            if (id != passenger.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
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

        // POST: api/Passengers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostPassenger(Passenger passenger)
        {
            var address = await _context.Address.Where(address => address.Id == passenger.Address.Id).FirstOrDefaultAsync();

            if (address != null)
            {
                passenger.Address = address;
            }
            else if(address == null)
            {

                var address_viacep = await Viacep.GetAddressViaCep(passenger.Address.PostalCode);
                passenger.Address = new Address(passenger.Address.PostalCode, address_viacep.Street, passenger.Address.Number, address_viacep.District, address_viacep.City, passenger.Address.Country, address_viacep.Federative_Unit, address_viacep.Complement);

            }

                _context.Passenger.Add(passenger);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassengerExists(passenger.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassenger", new { id = passenger.Cpf }, passenger);
        }

        // DELETE: api/Passengers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(string id)
        {
            var passenger = await _context.Passenger.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }

            _context.Passenger.Remove(passenger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassengerExists(string id)
        {
            return _context.Passenger.Any(e => e.Cpf == id);
        }
    }
}
