using PetitionBackend.DTOs;
using PetitionBackend.Models;
using System.Runtime.CompilerServices;

namespace PetitionBackend.Interfaces
{
    public interface IUserService
    {
        public Task<string> Login(Login login);
        public Task<User> Register(Register register,string ip);
        public Task<User> UpdateEmail(int id, string email);
        public Task DeleteSelf();
        public Task<User> GetById(int id);
        public Task<List<User>> GetAll(int page);
        public Task DeleteById(int id);
    }
}
