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
    public class PlansController : ControllerBase
    {
        private readonly TCcontext _context;

        public PlansController(TCcontext context)
        {
            _context = context;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlans()
        {
          if (_context.Plans == null)
          {
              return NotFound();
          }
            var plans = await _context.Plans.ToListAsync();
            foreach (var plan in plans)
            {
                var devices = await _context.Devices.Where(d => d.PlanId == plan.PlanId).ToListAsync();
                plan.Devices = devices;
            }
            return plans;
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanDetailsDTO>> GetPlan(int id)
        {
          if (_context.Plans == null)
          {
              return NotFound();
          }
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices.Where(d => d.PlanId == plan.PlanId).ToListAsync();
            var pDTO = new PlanDetailsDTO
            {
                PlanId = plan.PlanId,
                Type = plan.Type,
                PhoneLines = plan.PhoneLines,
                NumberLines = plan.NumberLines,
                UserId = plan.UserId,
                Devices = devices
            };
            return Ok(pDTO);
        }

        // PUT: api/Plans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, PlanDTO dto)
        {
            var plan = new Plan(dto, id);
            if (id != plan.PlanId)
            {
                return BadRequest();
            }
            if (plan.Devices == null)
            {
                var devices = await _context.Devices.Where(d => d.PlanId == plan.PlanId).ToListAsync();
                plan.Devices = devices;
            }

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
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

        // POST: api/Plans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(PlanDTO dto)
        {
          if (_context.Plans == null)
          {
              return Problem("Entity set 'TCcontext.Plans'  is null.");
          }
            var plan = new Plan(dto);
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.PlanId }, plan);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            if (_context.Plans == null)
            {
                return NotFound();
            }
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanExists(int id)
        {
            return (_context.Plans?.Any(e => e.PlanId == id)).GetValueOrDefault();
        }
    }
}
