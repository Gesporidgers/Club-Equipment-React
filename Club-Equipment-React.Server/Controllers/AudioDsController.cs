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
    public class AudioDsController : ControllerBase
    {
        private readonly AD_context _context;

        public AudioDsController(AD_context context)
        {
            _context = context;
        }

        // GET: api/AudioDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AudioD>>> Getaudio_devices()
        {
            return await _context.audio_devices.ToListAsync();
        }

        // GET: api/AudioDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AudioD>> GetAudioD(long id)
        {
            var audioD = await _context.audio_devices.FindAsync(id);

            if (audioD == null)
            {
                return NotFound();
            }

            return audioD;
        }

        // PUT: api/AudioDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudioD(long id, AudioD audioD)
        {
            if (id != audioD.Id)
            {
                return BadRequest();
            }

            _context.Entry(audioD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudioDExists(id))
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

        // POST: api/AudioDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AudioD>> PostAudioD(AudioD audioD)
        {
            _context.audio_devices.Add(audioD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAudioD", new { id = audioD.Id }, audioD);
        }

        // DELETE: api/AudioDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudioD(long id)
        {
            var audioD = await _context.audio_devices.FindAsync(id);
            if (audioD == null)
            {
                return NotFound();
            }

            _context.audio_devices.Remove(audioD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AudioDExists(long id)
        {
            return _context.audio_devices.Any(e => e.Id == id);
        }
    }
}
