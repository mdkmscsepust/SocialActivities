using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.API.Models.Entities
{
    public class Like : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}