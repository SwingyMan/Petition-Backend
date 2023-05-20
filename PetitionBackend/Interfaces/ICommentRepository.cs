using PetitionBackend.Models;

namespace PetitionBackend.Interfaces
{
    public interface ICommentRepository : ICrudRepository<Comment>
    {
        public Task<Comment> UpdateContent(int id, string content);


    }
}
