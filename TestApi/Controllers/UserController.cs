using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.DAL;
using TestApi.Domain;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<User>> Registration(string login, string password, string email)
        {
            using MyDbContext dbContext = new MyDbContext();
            var checkMail = await dbContext.Users.FindAsync(email);

            if (checkMail == null)
            {
                var user = new User(login, password, email);
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                return user;
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<long>> Login(string login, string password)
        {
            await using MyDbContext dbContext = new MyDbContext();

            var user = dbContext.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == Domain.User.ToHash(password));

            if (user == null)
            {
                return NotFound();
            }

            return user.Id;
        }
    }
}
