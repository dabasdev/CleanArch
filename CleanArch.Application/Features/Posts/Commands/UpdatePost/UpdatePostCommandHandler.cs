using AutoMapper;
using CleanArch.Application.Contracts;
using CleanArch.Domain;
using MediatR;

namespace CleanArch.Application.Features.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request);
        await _postRepository.UpdateAsync(post);

        return Unit.Value;
    }
}