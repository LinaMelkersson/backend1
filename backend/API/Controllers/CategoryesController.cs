using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryesController : ControllerBase
    {
        private readonly SqlContext _context;

        public CategoryesController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Categoryes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorye>>> GetCategoryes()
        {
            return await _context.Categoryes.ToListAsync();
        }

        // GET: api/Categoryes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorye>> GetCategorye(int id)
        {
            var categorye = await _context.Categoryes.FindAsync(id);

            if (categorye == null)
            {
                return NotFound();
            }

            return categorye;
        }

        // PUT: api/Categoryes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorye(int id, Categorye categorye)
        {
            if (id != categorye.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorye).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryeExists(id))
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

        // POST: api/Categoryes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorye>> PostCategorye(Categorye categorye)
        {
            _context.Categoryes.Add(categorye);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorye", new { id = categorye.Id }, categorye);
        }

        // DELETE: api/Categoryes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorye(int id)
        {
            var categorye = await _context.Categoryes.FindAsync(id);
            if (categorye == null)
            {
                return NotFound();
            }

            _context.Categoryes.Remove(categorye);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryeExists(int id)
        {
            return _context.Categoryes.Any(e => e.Id == id);
        }
    }
}
