namespace PetitionBackend.Models
{
    public class Sketch
    {
        public int SketchId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DateOfCreation { get; set; }
        public List<Comment> Comments { get; set; }
        public Documentation Documentation { get; set; }
        public User User { get; set; }
        //user->sketch 1->n
    }
}
