using System.ComponentModel.DataAnnotations;

namespace PetitionBackend.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Date_Of_Creation { get; set; }
        public Sketch? Sketch { get; set; }
        public User? User { get; set; }

        public Comment(string Content, int CommentId) 
        {
            this.CommentId = CommentId;
            this.Content = Content;
            Date_Of_Creation=DateTime.Now;

        }
    }
}
