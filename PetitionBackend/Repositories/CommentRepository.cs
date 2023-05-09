using PetitionBackend.Interfaces;
using PetitionBackend.Models;

namespace PetitionBackend.Repositories
{
    public class CommentRepository : CrudRepository<Comment>, ICommentRepository
    {
    }
}
