using PetitionBackend.Models;

namespace PetitionBackend.Interfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
        public Task<User> FindByEmailAndPassword(string email, string password);
        public Task<User> FindByEmail(string email);
        public Task<User> UpdateEmail(int id, string email);
        public Task<User> UpdatePassword(int id, string password);
    }
}
