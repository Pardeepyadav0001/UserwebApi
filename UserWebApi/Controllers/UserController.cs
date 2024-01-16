using EntityframeworkCore.MySql.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Models;

namespace EntityframeworkCore.MySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]

        public async Task<IActionResult> AddProduct(User Users)
        {
            _appDbContext.Users.Add(Users);
            await _appDbContext.SaveChangesAsync();
            return Ok(User);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.username == login.Username && u.password == login.Password);

            if (user == null)
            {
                return Unauthorized(); // Return 401 if username or password is incorrect
            }

            // Additional logic for successful login, e.g., generate a token or set a session cookie
            // For simplicity, let's just return the user information for now
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _appDbContext.Users.ToListAsync();

            return Ok(products);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.username == username);

            if (user == null)
            {
                return NotFound();
            }

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
