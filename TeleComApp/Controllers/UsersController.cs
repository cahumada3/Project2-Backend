using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleComApp.Data;
using TeleComApp.Models;
using TeleComApp.DTO;

namespace TeleComApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TCcontext _context;

        public UsersController(TCcontext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var users =  await _context.Users.ToListAsync();
            foreach (var user in users)
            {
                var devices = await _context.Devices.Where(d => d.UserId == user.UserId).ToListAsync();
                var plans = await _context.Plans.Where(p => p.UserId == user.UserId).ToListAsync();
                user.Devices = devices;
                user.Plans = plans;
            }
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsDTO>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var devices = await _context.Devices.Where(d => d.UserId == user.UserId).ToListAsync();
            var plans = await _context.Plans.Where(p => p.UserId == user.UserId).ToListAsync();
            var uDTO = new UserDetailsDTO
            {
                UserId = user.UserId,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Devices = devices,
                Plans = plans
            };

            return Ok(uDTO);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO dto)
        {
            var user = new User(dto, id);
            if (user.Devices == null)
            {
                var devices = await _context.Devices.Where(d => d.UserId == user.UserId).ToListAsync();
                user.Devices = devices;
            }
            if (user.Plans == null)
            {
                var plans = await _context.Plans.Where(p => p.UserId == user.UserId).ToListAsync();
                user.Plans = plans;
            }
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO dto)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'TCcontext.Users'  is null.");
          }
            var user = new User(dto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
