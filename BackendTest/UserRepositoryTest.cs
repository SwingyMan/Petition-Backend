using Moq;
using PetitionBackend.Models;
using PetitionBackend.Repositories;

namespace BackendTest
{
    public class Tests
    {
        User user = new User("Marcin", "test@gmail.com", "password", "79.124.122.222");
        Mock<UserRepository> mock = new Mock<UserRepository>();
        private readonly UserRepository mockRepository;
        [SetUp]
        public void Setup()
        {

            mock.Setup(x => x.add(user)).ReturnsAsync(user);
        }

        [Test]
        public void Test1()
        {
        }
    }
}