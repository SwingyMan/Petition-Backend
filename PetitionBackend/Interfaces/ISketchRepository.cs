using PetitionBackend.Models;

namespace PetitionBackend.Interfaces
{
    public interface ISketchRepository : ICrudRepository<Sketch>
    {

        public Task<Sketch> AddComentToSketch(int id, Comment comment);


    }
}
