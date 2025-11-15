using Backend.API.Models;
using Backend.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}