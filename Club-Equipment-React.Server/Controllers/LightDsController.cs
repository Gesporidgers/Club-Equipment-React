using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Club_Equipment_React.Server;

namespace Club_Equipment_React.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightDsController : ControllerBase
    {
        private readonly LD_context _context;

        public LightDsController(LD_context context)
        {
            _context = context;
        }

        // GET: api/LightDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LightD>>> Getlight_devices()
        {
            return await _context.light_devices.ToListAsync();
        }

        // GET: api/LightDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LightD>> GetLightD(long id)
        {
            var lightD = await _context.light_devices.FindAsync(id);

            if (lightD == null)
            {
                return NotFound();
            }

            return lightD;
        }

        // PUT: api/LightDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLightD(long id, LightD lightD)
        {
            if (id != lightD.Id)
            {
                return BadRequest();
            }

            _context.Entry(lightD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LightDExists(id))
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

        // POST: api/LightDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LightD>> PostLightD(LightD lightD)
        {
            _context.light_devices.Add(lightD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLightD", new { id = lightD.Id }, lightD);
        }

        // DELETE: api/LightDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLightD(long id)
        {
            var lightD = await _context.light_devices.FindAsync(id);
            if (lightD == null)
            {
                return NotFound();
            }

            _context.light_devices.Remove(lightD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LightDExists(long id)
        {
            return _context.light_devices.Any(e => e.Id == id);
        }
    }
}
