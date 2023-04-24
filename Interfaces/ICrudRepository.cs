namespace WebApplication1.Interfaces
{
    public interface ICrudRepository<T>
    {
        public Task<T> getById(int id);
        public Task<List<T>> getAll();
        public Task<T> updateById(int id,T entity);
        public Task<T> deleteById(int id);
        public Task<T> add(T entity);
        public Task<T> deleteAll();
    }
}
