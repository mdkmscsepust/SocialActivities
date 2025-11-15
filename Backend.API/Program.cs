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
using Microsoft.EntityFrameworkCore;

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
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
