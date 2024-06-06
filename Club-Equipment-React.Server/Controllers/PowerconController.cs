using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Club_Equipment_React.Server;
using Club_Equipment_React.Server.Models;

namespace Club_Equipment_React.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerconController : ControllerBase
    {
        private readonly Power_context _context;

        public PowerconController(Power_context context)
        {
            _context = context;
        }

        // GET: api/Powercon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cable>>> Getpowercons()
        {
            return await _context.powercons.ToListAsync();
        }

        // GET: api/Powercon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cable>> GetCable(long id)
        {
            var cable = await _context.powercons.FindAsync(id);

            if (cable == null)
            {
                return NotFound();
            }

            return cable;
        }

        // PUT: api/Powercon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCable(long id, Cable cable)
        {
            if (id != cable.Id)
            {
                return BadRequest();
            }

            _context.Entry(cable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CableExists(id))
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

        // POST: api/Powercon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cable>> PostCable(Cable cable)
        {
            _context.powercons.Add(cable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCable", new { id = cable.Id }, cable);
        }

        // DELETE: api/Powercon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCable(long id)
        {
            var cable = await _context.powercons.FindAsync(id);
            if (cable == null)
            {
                return NotFound();
            }

            _context.powercons.Remove(cable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CableExists(long id)
        {
            return _context.powercons.Any(e => e.Id == id);
        }
    }
}
