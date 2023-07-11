using PetitionBackend.Models;

namespace PetitionBackend.Interfaces
{
    public interface ICommentService
    {
        ICollection<Comment> GetComments();
        Comment GetComment(int id);

        bool CommentExistsOnSketch(int id);

        bool CommentExistsOnUser(int id);

        bool CommentExists(int id);

        ICollection<Comment> GetCommentsForSketch(int id);
        ICollection<Comment> GetCommentsForUser(int id);

        bool CreateComment(Comment comment);

        bool UpdateComment(Comment comment);

        bool DeleteComment(Comment comment);

        bool DeleteCommentsForSketch(List<Comment> comments);

        bool Save();
    }
}
