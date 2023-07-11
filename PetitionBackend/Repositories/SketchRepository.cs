using Microsoft.EntityFrameworkCore;
using PetitionBackend.Interfaces;
using PetitionBackend.Models;

namespace PetitionBackend.Repositories
{
    public class SketchRepository : CrudRepository<Sketch>, ISketchRepository
    {
        private readonly MainContext _mainContext;
        public SketchRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

      
    }
}
