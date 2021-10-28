using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExtraHoursAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExtraHoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationsController : ControllerBase
    {
        private readonly HoursContext _context;

        public ApplicationsController(HoursContext context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applications>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Applications>> GetApplications(int id)
        {
            var applications = await _context.Applications.FindAsync(id);

            if (applications == null)
            {
                return NotFound();
            }

            return applications;
        }

        [HttpGet("GetApplicationsbyColaborator/{colaborator}")]
        [Authorize(Roles = "5")]
        public async Task<ActionResult<IEnumerable<Applications>>> GetApplicationsbyColaborator(int colaborator)
        {

            return await _context.Applications.Where(a => a.Colaborator == colaborator).ToListAsync();

        }

        [HttpGet("GetApplicationsbyDate")]
        [Authorize(Roles = "5")]
        public async Task<ActionResult<IEnumerable<Applications>>> GetApplicationsbyDate()
        {

            DateTime today = DateTime.Now;
            DateTime firstDay = new DateTime(today.Year, today.Month, 1);


            return await _context.Applications.Where(a => a.ApplicationDate >= firstDay
                                                    && a.ApplicationDate <= today).ToListAsync();

        }


        [HttpGet("GetApplicationsbyStatus/{status}")]
        [Authorize(Roles = "6")]
        public async Task<ActionResult<IEnumerable<Applications>>> GetApplicationsbyStatus(int status)
        {

            if (status == 1)
            {
                var appState = true;
                return await _context.Applications.Where(a => a.ApplicationStatus == appState).ToListAsync();
            }
            else {
                var appState = false;
                return await _context.Applications.Where(a => a.ApplicationStatus == appState).ToListAsync();
            }
            

        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize(Roles = "6")]
        public async Task<IActionResult> PutApplications(int id, Applications applications)
        {
            if (id != applications.IdApplication)
            {
                return BadRequest();
            }

            _context.Entry(applications).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationsExists(id))
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

        // POST: api/Applications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Roles = "6")]
        public async Task<ActionResult<Applications>> PostApplications(Applications applications)
        {
            _context.Applications.Add(applications);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplications", new { id = applications.IdApplication }, applications);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Applications>> DeleteApplications(int id)
        {
            var applications = await _context.Applications.FindAsync(id);
            if (applications == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(applications);
            await _context.SaveChangesAsync();

            return applications;
        }

        private bool ApplicationsExists(int id)
        {
            return _context.Applications.Any(e => e.IdApplication == id);
        }
    }
}
