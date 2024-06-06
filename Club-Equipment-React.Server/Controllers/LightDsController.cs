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
    public class LightDsController : ControllerBase
    {
        private readonly LD_context _context;

        public LightDsController(LD_context context)
        {
            _context = context;
        }

        // GET: api/LightDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> Getlight_devices()
        {
            return await _context.light_devices.ToListAsync();
        }

        // GET: api/LightDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(long id)
        {
            var device = await _context.light_devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/LightDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(long id, Device device)
        {
            if (id != device.Id)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            _context.light_devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.Id }, device);
        }

        // DELETE: api/LightDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(long id)
        {
            var device = await _context.light_devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.light_devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(long id)
        {
            return _context.light_devices.Any(e => e.Id == id);
        }
    }
}
