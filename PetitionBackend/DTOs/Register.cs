namespace PetitionBackend.DTOs
{
    public class Register
    {
        public string email {get;set;}
        public string password { get;set; }
        public string name { get;set;}
        public void HashPassword()
        {
            password = BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
