using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime date_of_registration { get; set; }
        public string Role { get; set; }
        public string ip_of_registry { get; set; }
        public User(string name,string email,string password,string ip_of_registry)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            date_of_registration = DateTime.Now;
            Role = "User";
            this.ip_of_registry = ip_of_registry;
        }
    }
}
