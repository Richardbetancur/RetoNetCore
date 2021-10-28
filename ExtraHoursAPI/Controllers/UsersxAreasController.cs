using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExtraHoursAPI.Models;

namespace ExtraHoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersxAreasController : ControllerBase
    {
        private readonly HoursContext _context;

        public UsersxAreasController(HoursContext context)
        {
            _context = context;
        }

        // GET: api/UsersxAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersxAreas>>> GetUsersxAreas()
        {
            return await _context.UsersxAreas.ToListAsync();
        }

        // GET: api/UsersxAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersxAreas>> GetUsersxAreas(int id)
        {
            var usersxAreas = await _context.UsersxAreas.FindAsync(id);

            if (usersxAreas == null)
            {
                return NotFound();
            }

            return usersxAreas;
        }

        // PUT: api/UsersxAreas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersxAreas(int id, UsersxAreas usersxAreas)
        {
            if (id != usersxAreas.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersxAreas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersxAreasExists(id))
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

        // POST: api/UsersxAreas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsersxAreas>> PostUsersxAreas(UsersxAreas usersxAreas)
        {
            _context.UsersxAreas.Add(usersxAreas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersxAreas", new { id = usersxAreas.Id }, usersxAreas);
        }

        // DELETE: api/UsersxAreas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersxAreas>> DeleteUsersxAreas(int id)
        {
            var usersxAreas = await _context.UsersxAreas.FindAsync(id);
            if (usersxAreas == null)
            {
                return NotFound();
            }

            _context.UsersxAreas.Remove(usersxAreas);
            await _context.SaveChangesAsync();

            return usersxAreas;
        }

        private bool UsersxAreasExists(int id)
        {
            return _context.UsersxAreas.Any(e => e.Id == id);
        }
    }
}
