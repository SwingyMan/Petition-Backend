using PetitionBackend.Interfaces;
using PetitionBackend.Models;

namespace PetitionBackend.Repositories
{
    public class SketchRepository : CrudRepository<Sketch>, ISketchRepository
    {
        private readonly MainContext _mainContext;
        public UserRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public Task<Sketch> AddComentToSketch(int id, Comment comment)
        {



        }






    }
}
