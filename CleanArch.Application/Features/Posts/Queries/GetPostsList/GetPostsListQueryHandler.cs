using AutoMapper;
using CleanArch.Application.Contracts;
using CleanArch.Application.Dto.PostDtos;
using MediatR;

namespace CleanArch.Application.Features.Posts.Queries.GetPostsList;

public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<PostsListForViewDto>>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public GetPostsListQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostsListForViewDto>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
    {
        var allPosts = await _postRepository.GetAllPostsAsync(true);
        return _mapper.Map<List<PostsListForViewDto>>(allPosts);
    }
}