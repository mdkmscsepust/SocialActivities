using Backend.API.Models.Entities;
using Backend.API.Models.Requests;
using Backend.API.Models.Responses;
using Mapster;

namespace Backend.API.Helper
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<CategoryInDto, Category>.NewConfig();
            TypeAdapterConfig<Category, CategoryOutDto>.NewConfig();
            TypeAdapterConfig<Category, DropdownOutDto>.NewConfig();

            TypeAdapterConfig<ContactInDto, Contact>.NewConfig();
            TypeAdapterConfig<Contact, ContactOutDto>.NewConfig();

            TypeAdapterConfig<LikeInDto, Like>.NewConfig();
            TypeAdapterConfig<Like, LikeOutDto>.NewConfig();

            TypeAdapterConfig<CommentInDto, Comment>.NewConfig();
            TypeAdapterConfig<Comment, CommentOutDto>.NewConfig();

            TypeAdapterConfig<PostInDto, Post>.NewConfig();
            TypeAdapterConfig<Post, PostOutDto>.NewConfig();

            TypeAdapterConfig.GlobalSettings.Scan(typeof(MapsterConfig).Assembly);
        }
    }
}