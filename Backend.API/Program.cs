using System.Text;
using Backend.API.Database;
using Backend.API.Helper;
using Backend.API.Repositories.CategoryRepository;
using Backend.API.Repositories.CommentRepository;
using Backend.API.Repositories.ContactRepository;
using Backend.API.Repositories.LikeRepository;
using Backend.API.Repositories.PostRepository;
using Backend.API.Services;
using Backend.API.Services.CommentService;
using Backend.API.Services.ContactService;
using Backend.API.Services.LikeService;
using Backend.API.Services.PostService;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var config = TypeAdapterConfig.GlobalSettings;
builder.Services.AddSingleton(config);
MapsterConfig.RegisterMappings();
builder.Services.AddMapster();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])
            ),
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddScoped<IMapper, ServiceMapper>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
