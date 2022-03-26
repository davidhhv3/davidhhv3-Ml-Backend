using Backend.Models;
using Microsoft.AspNetCore.Mvc;



namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private IUserCollection db = new UserCollection();
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await db.GetUsers());

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {

            var user = await db.GetUser(id);
            return Ok(user);
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await db.InsertUser(user);            
            return Created("Usuario creado",user);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user, string id)
        {

            user.Id = id;
            await db.UpdateUser(id, user);            
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await db.DeleteUser(id);
            return NoContent();

        }
    }
}
