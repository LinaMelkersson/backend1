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
    public class OderLinesController : ControllerBase
    {
        private readonly SqlContext _context;

        public OderLinesController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/OderLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OderLine>>> GetOderLines()
        {
            return await _context.OderLines.ToListAsync();
        }

        // GET: api/OderLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OderLine>> GetOderLine(int id)
        {
            var oderLine = await _context.OderLines.FindAsync(id);

            if (oderLine == null)
            {
                return NotFound();
            }

            return oderLine;
        }

        // PUT: api/OderLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOderLine(int id, OderLine oderLine)
        {
            if (id != oderLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(oderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OderLineExists(id))
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

        // POST: api/OderLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OderLine>> PostOderLine(OderLine oderLine)
        {
            _context.OderLines.Add(oderLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOderLine", new { id = oderLine.Id }, oderLine);
        }

        // DELETE: api/OderLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOderLine(int id)
        {
            var oderLine = await _context.OderLines.FindAsync(id);
            if (oderLine == null)
            {
                return NotFound();
            }

            _context.OderLines.Remove(oderLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OderLineExists(int id)
        {
            return _context.OderLines.Any(e => e.Id == id);
        }
    }
}
