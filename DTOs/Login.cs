using BCrypt.Net;

namespace PetitionBackend.DTOs
{
    public class Login
    {
        public string email {  get; set; }
        public string password { get; set; }
        public void hashPassword() {
            password = BCrypt.Net.BCrypt.HashPassword(password); }
    }
}
