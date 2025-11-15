namespace Backend.API.Models.Responses
{
    public class PostOutDto : BaseOutDto
    {
        public string Tag { get; set; } 
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}