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
    public class VideoCBlController : ControllerBase
    {
        private readonly VideoCable_context _context;

        public VideoCBlController(VideoCable_context context)
        {
            _context = context;
        }

        // GET: api/VideoCBl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cable>>> Getvideo_cables()
        {
            return await _context.video_cables.ToListAsync();
        }

        // GET: api/VideoCBl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cable>> GetCable(long id)
        {
            var cable = await _context.video_cables.FindAsync(id);

            if (cable == null)
            {
                return NotFound();
            }

            return cable;
        }

        // PUT: api/VideoCBl/5
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

        // POST: api/VideoCBl
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cable>> PostCable(Cable cable)
        {
            _context.video_cables.Add(cable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCable", new { id = cable.Id }, cable);
        }

        // DELETE: api/VideoCBl/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCable(long id)
        {
            var cable = await _context.video_cables.FindAsync(id);
            if (cable == null)
            {
                return NotFound();
            }

            _context.video_cables.Remove(cable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CableExists(long id)
        {
            return _context.video_cables.Any(e => e.Id == id);
        }
    }
}
