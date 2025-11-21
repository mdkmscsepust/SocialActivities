using AppointmentManagement.API.Models.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.API.Models.Domains;

namespace AppointmentManagement.API.Data;

public class AppDbContext : IdentityDbContext<User, Role, int>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}