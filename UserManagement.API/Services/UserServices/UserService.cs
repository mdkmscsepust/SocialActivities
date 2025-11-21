using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppointmentManagement.API.Models.Domains;
using AppointmentManagement.API.Models.DTOs.IN;
using AppointmentManagement.API.Models.DTOs.OUT;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AppointmentManagement.API.Services.UserServices;

public class UserService(UserManager<User> userManager, IConfiguration config) : IUserService
{
    public async Task<LoginOutDTO> UserLogin(UserLogin request)
    {
        try
        {
            var user = await userManager.FindByNameAsync(request.Username);
            if(user is null) return new LoginOutDTO();
            var checkPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
            if(!checkPasswordValid) return new LoginOutDTO();
            var token = GenerateToken(user);
            return new LoginOutDTO() {
                AccessToken = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(config.GetValue<int>("jwt:ExpiredTime")),
                User = new UserOutDTO() {
                  Username = user.UserName
                }
            };

        }
        catch ( Exception ex )
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> UserRegistration(UserRegistrationInDTO request)
    {
        try
        {
            var userRegistration = new User() {  UserName = request.UserName};
            var result = await userManager.CreateAsync(userRegistration, request.Password);
            if(!result.Succeeded) return false;
            return true;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim> {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var token = new JwtSecurityToken(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(config.GetValue<int>("Jwt:ExpiredTime")),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}