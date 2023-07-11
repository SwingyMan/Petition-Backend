using PetitionBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace PetitionBackend.DTOs
{
    public class CommentDto
    {
      
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Date_Of_Creation { get; set; }

        public CommentDto(string Content, int CommentId)
        {
            this.CommentId = CommentId;
            this.Content = Content;
            Date_Of_Creation = DateTime.Now;

        }


    }
}
