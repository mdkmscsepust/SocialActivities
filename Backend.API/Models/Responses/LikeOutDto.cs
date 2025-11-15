namespace Backend.API.Models.Responses
{
    public class LikeOutDto : BaseOutDto
    {
       public int PostId { get; set; }
        public int UserId { get; set; } 
    }
}