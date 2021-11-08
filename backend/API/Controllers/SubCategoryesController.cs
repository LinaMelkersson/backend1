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
    public class SubCategoryesController : ControllerBase
    {
        private readonly SqlContext _context;

        public SubCategoryesController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/SubCategoryes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategorye>>> GetSubCategoryes()
        {
            return await _context.SubCategoryes.ToListAsync();
        }

        // GET: api/SubCategoryes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategorye>> GetSubCategorye(int id)
        {
            var subCategorye = await _context.SubCategoryes.FindAsync(id);

            if (subCategorye == null)
            {
                return NotFound();
            }

            return subCategorye;
        }

        // PUT: api/SubCategoryes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategorye(int id, SubCategorye subCategorye)
        {
            if (id != subCategorye.Id)
            {
                return BadRequest();
            }

            _context.Entry(subCategorye).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryeExists(id))
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

        // POST: api/SubCategoryes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubCategorye>> PostSubCategorye(SubCategorye subCategorye)
        {
            _context.SubCategoryes.Add(subCategorye);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubCategorye", new { id = subCategorye.Id }, subCategorye);
        }

        // DELETE: api/SubCategoryes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategorye(int id)
        {
            var subCategorye = await _context.SubCategoryes.FindAsync(id);
            if (subCategorye == null)
            {
                return NotFound();
            }

            _context.SubCategoryes.Remove(subCategorye);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubCategoryeExists(int id)
        {
            return _context.SubCategoryes.Any(e => e.Id == id);
        }
    }
}
