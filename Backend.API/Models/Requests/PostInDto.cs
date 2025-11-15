namespace Backend.API.Models.Requests
{
    public class PostInDto
    {
        public string Tag { get; set; }  = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public string Location { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}