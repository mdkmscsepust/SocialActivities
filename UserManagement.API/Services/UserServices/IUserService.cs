using AppointmentManagement.API.Models.DTOs.IN;
using AppointmentManagement.API.Models.DTOs.OUT;

namespace AppointmentManagement.API.Services.UserServices;

public interface IUserService
{
    Task<bool> UserRegistration(UserRegistrationInDTO request);
    Task<LoginOutDTO> UserLogin(UserLogin request);
}