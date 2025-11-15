namespace Backend.API.Models.Requests
{
    public class ContactInDto
    {
        public int PostId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; } 
    }
}