namespace Backend.API.Models.Responses
{
    public class CommentOutDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}