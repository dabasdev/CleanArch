using AutoMapper;
using CleanArch.Application.Contracts;
using CleanArch.Application.Dto.PostDtos;
using MediatR;

namespace CleanArch.Application.Features.Posts.Queries.GetPostDetails;

public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, PostDetailForViewDto>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public GetPostDetailQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<PostDetailForViewDto> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetPostByIdAsync(request.PostId, true);

        return _mapper.Map<PostDetailForViewDto>(post);
    }
}