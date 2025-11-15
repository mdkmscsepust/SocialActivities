using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.API.Models.Entities
{
    public class Comment : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}