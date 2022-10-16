using HealthyME.Data;
using HealthyME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthyME.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HEMDbContext _userContext;

        public UserController(HEMDbContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_userContext.Users == null)
            {
                return NotFound();
            }
            return await _userContext.Users.ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUsers(int userId)
        {
            if (_userContext.Users == null)
            {
                return NotFound();
            }
            var users = await _userContext.Users.FindAsync(userId);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { UserId = user.UserId }, user);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int userId, User user)
        {
            if (userId != user.UserId)
            {
                return BadRequest();
            }
            _userContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!isUserExists(userId))
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

        private bool isUserExists(long userId)
        {
            return (_userContext.Users?.Any(e => e.UserId == userId)).GetValueOrDefault();
        }
    }
}
