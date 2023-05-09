using Microsoft.EntityFrameworkCore;
using PetitionBackend.Interfaces;
using PetitionBackend.Models;

namespace PetitionBackend.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        private readonly MainContext _mainContext;
        public UserRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }
        public async Task<User> FindByEmail(string email)
        {
            return await _mainContext.Users.FirstOrDefaultAsync(x=>x.Email==email);
        }

        public async Task<User> FindByEmailAndPassword(string email, string password)
        {

            return await _mainContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password ==password);
        }
            
        public async Task<User> UpdateEmail(int id, string email)
        {
            var original = await _mainContext.Users.FirstOrDefaultAsync(x=>x.Id==id);
            if(email!=null)
            {
                original.Email = email;
               await _mainContext.SaveChangesAsync();
                return original;
            }
            return original;
        }

        public async Task<User> UpdatePassword(int id, string password)
        {
            var original = await _mainContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (password != null)
            {
                original.Password = password;
                await _mainContext.SaveChangesAsync();
                return original;
            }
            return original;
        }
    }
}
