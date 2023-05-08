using System.ComponentModel.DataAnnotations;

namespace PetitionBackend.Models
{
    public class Supports
    {
        [Key]
        public int SupportID { get; set; }
        public string Comment { get; set; }
        public bool anonymous { get; set; }
        public User User { get; set; }
        public Petition Petition { get; set; }
    }
}
