using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.API.Models.Entities
{
    public class Contact : BaseEntity
    {
        public int PostId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; } 
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}