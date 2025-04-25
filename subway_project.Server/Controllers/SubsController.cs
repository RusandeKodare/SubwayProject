using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using subway_project.Server.Data;
using subway_project.Server.Models;
using subway_shared.DTOs.OrderDTOs;
using subway_shared.DTOs.SubDTOs;

namespace subway_project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SubsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Subs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sub>>> GetSub()
        {
            return await _context.Sub.ToListAsync();
        }

        // GET: api/Subs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sub>> GetSub(int id)
        {
            var sub = await _context.Sub.FindAsync(id);

            if (sub == null)
            {
                return NotFound();
            }

            return sub;
        }

        // PUT: api/Subs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSub(int id, Sub sub)
        //{
        //    if (id != sub.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(sub).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Subs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sub>> PostSub(SubDTO subDTO)
        {

            var sub = _mapper.Map<Sub>(subDTO);

            foreach (var productDTO in subDTO.Products)
            {
                var existingProduct = await _context.Products.FirstOrDefaultAsync(_=>_.Name == productDTO.Name);
                if (existingProduct != null && existingProduct.CategoryId == 2 && !sub.Products.Any(p=>p.CategoryId == 2))
                {
                    sub.Products.Add(existingProduct);

                }

                else if (existingProduct != null)
                {
                    sub.Products.Add(existingProduct);
                }

                else
                {
                    return NotFound(new { message = "Product not found or sub" });
                }
          
            }

            _context.Sub.Add(sub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSub", new { id = sub.Id }, sub);
        }

        //// DELETE: api/Subs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSub(int id)
        //{
        //    var sub = await _context.Sub.FindAsync(id);
        //    if (sub == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Sub.Remove(sub);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool SubExists(int id)
        {
            return _context.Sub.Any(e => e.Id == id);
        }
    }
}
