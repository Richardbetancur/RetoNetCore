using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExtraHoursAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ExtraHoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExtraHoursController : ControllerBase
    {
        private readonly HoursContext _context;

        public ExtraHoursController(HoursContext context)
        {
            _context = context;
        }

        // GET: api/ExtraHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtraHours>>> GetExtraHours()
        {
            return await _context.ExtraHours.ToListAsync();
        }

        // GET: api/ExtraHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExtraHours>> GetExtraHours(int id)
        {
            var extraHours = await _context.ExtraHours.FindAsync(id);

            if (extraHours == null)
            {
                return NotFound();
            }

            return extraHours;
        }

        // PUT: api/ExtraHours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtraHours(int id, ExtraHours extraHours)
        {
            if (id != extraHours.Id)
            {
                return BadRequest();
            }

            _context.Entry(extraHours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraHoursExists(id))
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

        // POST: api/ExtraHours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Roles = "6")]
        public async Task<ActionResult<ExtraHours>> PostExtraHours(ExtraHours extraHours)
        {
            _context.ExtraHours.Add(extraHours);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtraHours", new { id = extraHours.Id }, extraHours);
        }

        // DELETE: api/ExtraHours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExtraHours>> DeleteExtraHours(int id)
        {
            var extraHours = await _context.ExtraHours.FindAsync(id);
            if (extraHours == null)
            {
                return NotFound();
            }

            _context.ExtraHours.Remove(extraHours);
            await _context.SaveChangesAsync();

            return extraHours;
        }

        private bool ExtraHoursExists(int id)
        {
            return _context.ExtraHours.Any(e => e.Id == id);
        }
    }
}
