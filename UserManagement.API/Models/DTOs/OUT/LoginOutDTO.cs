namespace AppointmentManagement.API.Models.DTOs.OUT;

public class LoginOutDTO
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
    public UserOutDTO User { get; set; }
}