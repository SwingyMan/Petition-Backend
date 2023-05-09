using PetitionBackend.DTOs;
using PetitionBackend.Interfaces;
using PetitionBackend.Models;
using PetitionBackend.Repositories;

namespace PetitionBackend.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly MainContext _mainContext;
        public UserService(MainContext mainContext) { 
        _mainContext = mainContext;
            _userRepository = new UserRepository(mainContext);
        }

        public async Task DeleteById(int id)
        {
            await _userRepository.deleteById(id);
        }

        public Task DeleteSelf()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll(int page)
        {
            return await _userRepository.getAll(page);
        }

        public async Task<User> GetById(int id)
        {
           return await _userRepository.getById(id);
        }

        public async Task<string> Login(Login login)
        {
            login.hashPassword();
            var x = await _userRepository.FindByEmailAndPassword(login.email,login.password);
            if (x != null)
            {
                return "ok";
            }
            else { return "not found"; }
        }

        public async Task<User> Register(Register register,string ip)
        {
            register.HashPassword();
            var user = new User(register.name, register.email, register.password, ip);
            await _userRepository.add(user);
            return user;
        }

        public Task<User> UpdateEmail(int id, string email)
        {
            throw new NotImplementedException();
        }
    }
}
