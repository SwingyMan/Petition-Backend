namespace WebApplication1.Models
{
    public class Petition
    {
        public int PetitionId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int VoteOfSupport { get; set; }
        public Sketch sketches { get; set; }
        //Sketch -> Petition 1:1
        //Sketch -> Comment 1:n
        //User->Sketch 1:1
        //User-> Petition 1:1
        //Sketch -> Recipient 1:1
    }
}
