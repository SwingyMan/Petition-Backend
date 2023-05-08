using Microsoft.AspNetCore.Mvc;
using PetitionBackend.DTOs;
using PetitionBackend.Models;
using PetitionBackend.Services;

namespace PetitionBackend.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : ControllerBase
    {
        private readonly MainContext _mainContext;
        private readonly UserService _userService;
        public UserController(MainContext mainContext)
        {
            _mainContext = mainContext;
            _userService = new UserService(mainContext);
        }
        [HttpPost("/account/login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            return Ok(await _userService.Login(login));
        }
        [HttpGet("/account/{id}")]
        public async Task<IActionResult> ReadUser(int id)
        {
            return Ok(await _userService.GetById(id));
        }
        [HttpPost("/account/add")]
        public async Task<IActionResult> addUser([FromBody] Register userDTO)
        {
            return Ok(await _userService.Register(userDTO, HttpContext.Request.Host.ToString()));
        }
        [HttpPut("/account/edit")]
        public IActionResult editUser()
        {
            return Ok();
        }
        [HttpDelete("/account/delete/{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            return Ok(await _userService.DeleteById(id));
        }
    }
}
