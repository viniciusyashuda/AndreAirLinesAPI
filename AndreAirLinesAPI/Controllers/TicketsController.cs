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
    public class TicketsController : ControllerBase
    {
        private readonly AndreAirLinesAPIContext _context;

        public TicketsController(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            return await _context.Ticket.Include(ticket => ticket.Class)
                                        .Include(ticket => ticket.Flight)
                                        .Include(ticket => ticket.BasePrice)
                                        .Include(ticket => ticket.Passenger)
                                        .ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Ticket.Include(ticket => ticket.Class)
                                        .Include(ticket => ticket.Flight)
                                        .Include(ticket => ticket.BasePrice)
                                        .Include(ticket => ticket.Passenger)
                                        .Where(ticket => ticket.Id == id)
                                        .FirstOrDefaultAsync();

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {

            var flight = await _context.Flight.FindAsync(ticket.Flight.Id);
            if(flight != null)
            {
                ticket.Flight = flight;
            }
            var passenger = await _context.Passenger.FindAsync(ticket.Passenger.Cpf);
            if(passenger != null)
            {
                ticket.Passenger = passenger;
            }
            var class_type = await _context.Class.FindAsync(ticket.Class.Id);
            if(class_type != null)
            {
                ticket.Class = class_type;
            }
            var base_price = await _context.BasePrice.FindAsync(ticket.BasePrice.Id);
            if(base_price != null)
            {
                ticket.BasePrice = base_price;
            }

            ticket.TotalValue = (ticket.BasePrice.Value + ticket.Class.Class_Value) * (1 - ticket.SalePercentage);


            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
