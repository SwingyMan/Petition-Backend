namespace WebApplication1.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String Content { get; set; }
        public DateTime Date_Of_Creation { get; set; }
        public Sketch Sketch { get; set; }
        public User user { get; set; }
        //sketch->comment 1->n
    }
}
