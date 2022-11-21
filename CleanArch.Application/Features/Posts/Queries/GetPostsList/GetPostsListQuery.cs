using CleanArch.Application.Dto.PostDtos;
using MediatR;

namespace CleanArch.Application.Features.Posts.Queries.GetPostsList;

public class GetPostsListQuery : IRequest<List<PostsListForViewDto>>
{
}