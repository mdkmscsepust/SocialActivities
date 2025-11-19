namespace AppointmentManagement.API.Models.DTOs.IN;

public class UserRegistrationInDTO
{
    public required string UserName { get; set; }    
    public required string Password { get; set; }   
}