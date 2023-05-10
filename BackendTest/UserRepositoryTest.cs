using Moq;
using PetitionBackend.Controllers;
using PetitionBackend.Interfaces;
using PetitionBackend.Models;
using PetitionBackend.Repositories;
using PetitionBackend.Services;

namespace BackendTest
{
    public class Tests
    {
        public User user = new User("Marcin", "test@gmail.com", "password", "79.124.122.222");
        public Mock<IUserRepository> mock;
        public readonly MainContext mainContext;
        public UserService userService;
        [SetUp]
        public void Setup()
        {
            mock = new Mock<IUserRepository>();
            userService = new UserService(mock.Object);
            mock.Setup(x => x.getById(It.IsAny<int>())).ReturnsAsync(user);
        }

        [Test]
        public async Task ShouldReturnListOfUsers()
        {
            var result = await userService.GetById(1);
            Assert.AreEqual(result, user);
        }
    }
}