using AutoMapper;
using CleanArch.Application.Dto.PostDtos;
using CleanArch.Application.Features.Posts.Commands.CreatePost;
using CleanArch.Domain;

namespace CleanArch.Application.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Post, PostsListForViewDto>().ReverseMap();
        CreateMap<Post, PostDetailForViewDto>().ReverseMap();
        CreateMap<Post, CreatePostCommand>().ReverseMap();
    }
}