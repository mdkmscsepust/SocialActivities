namespace AppointmentManagement.API.Models.DTOs.IN;

public class UserLogin
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}