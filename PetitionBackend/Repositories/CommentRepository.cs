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

        public async Task<Comment> UpdateContent(int id, string content)
        {
            var original = await _mainContext.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            if(content!=null)
            {
                original.Content = content;
                await _mainContext.SaveChangesAsync();
                return original;

            }
            return original;
        }










    }
}
