using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/")]
    public class MainController : ControllerBase
    {
        // GET: MainController
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("It's working");
        }
    }
}
