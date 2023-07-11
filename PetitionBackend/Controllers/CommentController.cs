using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetitionBackend.DTOs;
using PetitionBackend.Interfaces;
using PetitionBackend.Models;

namespace PetitionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase, ICommentController
    {

        private readonly ICommentService _commentService;
        private readonly ISketchService _sketchService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, ISketchService sketchService, IUserService userService)
        {
            _commentService = commentService;
            _sketchService = sketchService;
            _userService   = userService;
        }

 
        [HttpGet("getComments")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comment>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetComments()
        {
            var comments = _commentService.GetComments();
            List<CommentDto> commentsDto = new List<CommentDto>();

            foreach (Comment comment in comments)
            {
                var commentDto = new CommentDto(comment.Content, comment.CommentId);
                commentsDto.Add(commentDto);

            }

            if(commentsDto==null )
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest("Coś poszło nie tak");

            return Ok(commentsDto);

        }

        [HttpGet("getCommentsByUserId{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comment>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentsByUserId(int userId)
        {
            if(!_commentService.CommentExistsOnUser(userId))
            {
                return NotFound("Nie znaleziono komntarzy");
            }

            var comments = _commentService.GetCommentsForUser(userId);
            List<CommentDto> commentsDto = new List<CommentDto>();

            foreach (Comment comment in comments)
            {
                var commentDto = new CommentDto(comment.Content, comment.CommentId);
                commentsDto.Add(commentDto);

            }

            if (!ModelState.IsValid)
                return BadRequest("Coś poszło nie tak");

            return Ok(commentsDto);

        }

        [HttpGet("getCommentsBySketchId{sketchId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comment>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentsBySketchId(int sketchId)
        {
            if (!_commentService.CommentExistsOnSketch(sketchId))
            {
                return NotFound("Nie znaleziono komntarzy");
            }

            var comments = _commentService.GetCommentsForSketch(sketchId);
            List<CommentDto> commentsDto = new List<CommentDto>();

            foreach (Comment comment in comments)
            {
                var commentDto = new CommentDto(comment.Content, comment.CommentId);
                commentsDto.Add(commentDto);

            }

            if (!ModelState.IsValid)
                return BadRequest("Coś poszło nie tak");

            return Ok(commentsDto);

        }


        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateComment([FromBody] CommentDto updatedComment)
        {
            if (updatedComment == null)
                return BadRequest("Komentarz jest pusta");

            if (!_commentService.CommentExists(updatedComment.CommentId))
                return NotFound("Nie znaleziono komentarza");

            if (!ModelState.IsValid)
                return BadRequest("Coś poszło nie tak");

            var commentMap = new Comment(updatedComment.Content, updatedComment.CommentId);

            if(!_commentService.UpdateComment(commentMap))
            {
                return BadRequest("Coś poszło nie tak przy zmianie komentarza");
            }

            return Ok("Pomyślnie zmodyfikowano komentarz");

        }


        [HttpDelete("{commentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            if (!_commentService.CommentExists(commentId))
                return NotFound("Nie znaleziono komentarza");

            var commentToDelete = _commentService.GetComment(commentId);

            if (!ModelState.IsValid)
                return BadRequest("Coś poszło nie tak");

            if(!_commentService.DeleteComment(commentToDelete))
            {
                return BadRequest("Coś poszło nie tak podczas usuwania komentarza");
            }

            return Ok("Pomyślnie usunięto komentarz");

        }


    }
}
