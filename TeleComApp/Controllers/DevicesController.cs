using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleComApp.Data;
using TeleComApp.DTO;
using TeleComApp.Models;

namespace TeleComApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly TCcontext _context;

        public DevicesController(TCcontext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
          if (_context.Devices == null)
          {
              return NotFound();
          }
            return await _context.Devices.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDetailsDTO>> GetDevice(int id)
        {
          if (_context.Devices == null)
          {
              return NotFound();
          }
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }
            var dto = new DeviceDetailsDTO
            {
                DeviceId = device.DeviceId,
                Model = device.Model,
                PhoneNumber = device.PhoneNumber,
                IsActive = device.IsActive,
                UserId = device.UserId,
                PlanId = device.PlanId,
            };

            return Ok(dto);
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, DeviceDTO dto)
        {
            var device = new Device(dto, id);
            if (id != device.DeviceId)
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

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(DeviceDTO dto)
        {
            if (_context.Devices == null)
            {
                return Problem("Entity set 'TCcontext.Devices'  is null.");
            }
            var device = new Device(dto);
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            if (_context.Devices == null)
            {
                return NotFound();
            }
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(int id)
        {
            return (_context.Devices?.Any(e => e.DeviceId == id)).GetValueOrDefault();
        }
    }
}
