using Microsoft.AspNetCore.Mvc;
using PetitionBackend.DTOs;
using PetitionBackend.Models;
using PetitionBackend.Repositories;
using PetitionBackend.Services;

namespace PetitionBackend.Controllers
{
    [ApiController]
    [Route("/api/account/")]
    public class UserController : ControllerBase
    {
        private readonly MainContext _mainContext;
        private readonly UserService _userService;
        private readonly UserRepository _userRepository;
        public UserController(MainContext mainContext)
        {
            _mainContext = mainContext;
            _userRepository = new UserRepository(_mainContext);
            _userService = new UserService(_userRepository);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
        if (login == null) { return BadRequest(); }
            return Ok(await _userService.Login(login));
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> ReadUser(int id)
        {
            return Ok(await _userService.GetById(id));
        }
        [HttpPost("register")]
        public async Task<IActionResult> addUser([FromBody] Register userDTO)
        {
            return Ok(await _userService.Register(userDTO, HttpContext.Request.Host.ToString()));
        }
        [HttpPut("edit/{id}")]
        public IActionResult editUser(int id)
        {
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            await _userService.DeleteById(id);
            return Ok();
        }
    }
}
