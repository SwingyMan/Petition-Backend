using Microsoft.EntityFrameworkCore;
using PetitionBackend.Interfaces;
using PetitionBackend.Models;

namespace PetitionBackend.Repositories
{
    public class CommentRepository : CrudRepository<Comment>, ICommentRepository
    {
        private readonly MainContext _mainContext;
        public CommentRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

   










    }
}
