using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.API.Models.Entities
{
    public class Post : BaseEntity
    {
        public string Tag { get; set; } 
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}