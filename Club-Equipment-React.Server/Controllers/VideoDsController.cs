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
    public class VideoDsController : ControllerBase
    {
        private readonly PhotoVideo_context _context;

        public VideoDsController(PhotoVideo_context context)
        {
            _context = context;
        }

        // GET: api/VideoDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> Getphoto_video()
        {
            return await _context.photo_video.ToListAsync();
        }

        // GET: api/VideoDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(long id)
        {
            var device = await _context.photo_video.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/VideoDs/5
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

        // POST: api/VideoDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            _context.photo_video.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.Id }, device);
        }

        // DELETE: api/VideoDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(long id)
        {
            var device = await _context.photo_video.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.photo_video.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(long id)
        {
            return _context.photo_video.Any(e => e.Id == id);
        }
    }
}
