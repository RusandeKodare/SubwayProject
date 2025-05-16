using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using subway_project.Server.Data;
using subway_project.Server.Models;

namespace subway_project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpecialsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Specials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specials>>> GetSpecials()
        {
            return await _context.Specials.Include(_=>_.SpecialProducts).ThenInclude(_=>_.Product).ToListAsync();
        }

        // GET: api/Specials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specials>> GetSpecials(int id)
        {
            var specials = await _context.Specials.FindAsync(id);

            if (specials == null)
            {
                return NotFound();
            }

            return specials;
        }

        // PUT: api/Specials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecials(int id, Specials specials)
        {
            if (id != specials.Id)
            {
                return BadRequest();
            }

            _context.Entry(specials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialsExists(id))
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

        // POST: api/Specials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Specials>> PostSpecials(Specials specials)
        {
            _context.Specials.Add(specials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecials", new { id = specials.Id }, specials);
        }

        // DELETE: api/Specials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecials(int id)
        {
            var specials = await _context.Specials.FindAsync(id);
            if (specials == null)
            {
                return NotFound();
            }

            _context.Specials.Remove(specials);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialsExists(int id)
        {
            return _context.Specials.Any(e => e.Id == id);
        }
    }
}
