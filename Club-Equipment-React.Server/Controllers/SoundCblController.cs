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
    public class SoundCblController : ControllerBase
    {
        private readonly SoundC_context _context;

        public SoundCblController(SoundC_context context)
        {
            _context = context;
        }

        // GET: api/SoundCbl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cable>>> Getsound_cables()
        {
            return await _context.sound_cables.ToListAsync();
        }

        // GET: api/SoundCbl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cable>> GetCable(long id)
        {
            var cable = await _context.sound_cables.FindAsync(id);

            if (cable == null)
            {
                return NotFound();
            }

            return cable;
        }

        // PUT: api/SoundCbl/5
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

        // POST: api/SoundCbl
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cable>> PostCable(Cable cable)
        {
            _context.sound_cables.Add(cable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCable", new { id = cable.Id }, cable);
        }

        // DELETE: api/SoundCbl/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCable(long id)
        {
            var cable = await _context.sound_cables.FindAsync(id);
            if (cable == null)
            {
                return NotFound();
            }

            _context.sound_cables.Remove(cable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CableExists(long id)
        {
            return _context.sound_cables.Any(e => e.Id == id);
        }
    }
}
