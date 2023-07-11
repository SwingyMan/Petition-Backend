using Microsoft.EntityFrameworkCore;
using PetitionBackend.Interfaces;
using PetitionBackend.Models;

namespace PetitionBackend.Services
{
    public class CommentService : ICommentService
    {
        private readonly MainContext _mainContext;

        public CommentService(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public bool CommentExists(int id)
        {
            return _mainContext.Comments.Any(o => o.CommentId == id);
        }

        public bool CommentExistsOnSketch(int id)
        {
            return _mainContext.Comments.Any(o => o.Sketch.SketchId == id);
        }

        public bool CommentExistsOnUser(int id)
        {
            return _mainContext.Comments.Any(o => o.User.Id == id);
        }

        public bool CreateComment(Comment comment)
        {
            _mainContext.Add(comment);
            return Save();
        }

        public bool DeleteComment(Comment comment)
        {
            _mainContext.Remove(comment);
            return Save();
        }

        public bool DeleteCommentsForSketch(List<Comment> comments)
        {
            _mainContext.RemoveRange(comments);
            return Save();
        }

        public Comment GetComment(int id)
        {
            return _mainContext.Comments.Where(o => o.CommentId == id).FirstOrDefault();
        }

        public ICollection<Comment> GetComments()
        {
            return _mainContext.Comments.OrderBy(o => o.CommentId).ToList();
        }

        public ICollection<Comment> GetCommentsForSketch(int id)
        {
            return _mainContext.Comments.Where(o => o.Sketch.SketchId == id).ToList();
        }

        public ICollection<Comment> GetCommentsForUser(int id)
        {
            return _mainContext.Comments.Where(o => o.User.Id == id).ToList();
        }

        public bool UpdateComment(Comment comment)
        {
            _mainContext.Update(comment);
            return Save();
        }


        public bool Save()
        {
            var saved = _mainContext.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
