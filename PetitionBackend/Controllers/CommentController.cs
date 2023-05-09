using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetitionBackend.Interfaces;

namespace PetitionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase, ICommentController
    {
    }
}
