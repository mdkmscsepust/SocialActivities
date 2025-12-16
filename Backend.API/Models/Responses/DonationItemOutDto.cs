using Backend.API.Helper;

namespace Backend.API.Models.Responses
{
    public class DonationItemOutDto : BaseOutDto
    {
       public int DonationId { get; set; }
        public int CategoryId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public EducationLevel Level { get; set; }
        public string? Subject { get; set; }
        public string Version { get; set; }
        public string? Author { get; set; }
        public ItemCondition? Condition { get; set; }
        public int Quantity { get; set; }
        public DonationStatus Status { get; set; }
        public string? Notes { get; set; } 
    }
}