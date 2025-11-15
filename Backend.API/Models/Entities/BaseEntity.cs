using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}