using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private MainContext _mainContext = null;
        private DbSet<T> table = null;
        public CrudRepository() {
            _mainContext = new MainContext();
            table = _mainContext.Set<T>();
        }
        public async Task<T> add(T entity)
        {
            table.Add(entity);
           await _mainContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> deleteAll()
        {
            var list = table.ToList();
            foreach (var item in list)
            {
                table.Remove(item);
            }
            await _mainContext.SaveChangesAsync();
            return null;
        }

        public async Task<T> deleteById(int id)
        {
            var entity = await table.FindAsync(id);
            table.Remove(entity);
            return null;
        }

        public async Task<List<T>> getAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> getById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> updateById(int id, T entity)
        {
            var entity1 = table.Find(id);
            entity1 = entity;
            await _mainContext.SaveChangesAsync();
            return entity1;
        }
    }
}
