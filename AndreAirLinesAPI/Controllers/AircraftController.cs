﻿using System;
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
    public class AircraftController : ControllerBase
    {
        private readonly AndreAirLinesAPIContext _context;

        public AircraftController(AndreAirLinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Aircraft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAircraft()
        {
            return await _context.Aircraft.ToListAsync();
        }

        // GET: api/Aircraft/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aircraft>> GetAircraft(string id)
        {
            var aircraft = await _context.Aircraft.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return aircraft;
        }

        // PUT: api/Aircraft/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraft(string id, Aircraft aircraft)
        {
            if (id != aircraft.Id)
            {
                return BadRequest();
            }

            _context.Entry(aircraft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
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

        // POST: api/Aircraft
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aircraft>> PostAircraft(Aircraft aircraft)
        {

            _context.Aircraft.Add(aircraft);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AircraftExists(aircraft.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAircraft", new { id = aircraft.Id }, aircraft);
        }

        // DELETE: api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft(string id)
        {
            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircraft.Remove(aircraft);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftExists(string id)
        {
            return _context.Aircraft.Any(e => e.Id == id);
        }
    }
}
