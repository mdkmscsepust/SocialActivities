using System.ComponentModel.DataAnnotations.Schema;
using Backend.API.Helper;

namespace Backend.API.Models.Entities
{
    [Table("DonationItems")]
    public class DonationItem : BaseEntity
    {
        public int DonationId { get; set; }
        public int CategoryId { get; set; }
        public string? Type { get; set; }                 // Academic, BCS, PEOM
        public string? Description { get; set; }          // Extra item details
        public EducationLevel Level { get; set; } = EducationLevel.ClassSix;
        public string? Subject { get; set; }              // English, Bangla
        public string Version { get; set; } = "2020";
        public string? Author { get; set; }
        public ItemCondition? Condition { get; set; }
        public int Quantity { get; set; }
        public DonationStatus Status { get; set; } = DonationStatus.Pending;
        public string? Notes { get; set; }
    }
}