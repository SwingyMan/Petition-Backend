using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/")]
    public class MainController : ControllerBase
    {
        private readonly MainContext _mainContext; 
        public MainController(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        [HttpGet("/account/{id}")]
        public IActionResult ReadUser(int id)
        {
            var user = _mainContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }
        [HttpPost("/account/add")]
        public IActionResult addUser([FromBody]UserDTO userDTO)
        {
            if(ModelState.IsValid) { return BadRequest(); }
            User user = new User(userDTO.Name, userDTO.Email, userDTO.Password, HttpContext.Request.Host.ToString());
            _mainContext.Users.Add(user);
            _mainContext.SaveChanges();
            return Ok(user);
        }
        [HttpPut("/account/edit")]
        public IActionResult editUser()
        {
            return Ok();
        }
        [HttpDelete("/account/delete/{id}")]
        public IActionResult deleteUser() { 
            return Ok();
        }
    }
}
