using AutoMapper;
using CleanArch.Application.Contracts;
using CleanArch.Domain;
using MediatR;

namespace CleanArch.Application.Features.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request);

        var validator = new CreatePostCommandValidator();

        var result = await validator.ValidateAsync(request, cancellationToken);

        if (result.Errors.Any()) throw new Exception("Post is not valid");

        post = await _postRepository.AddAsync(post);

        return post.Id;
    }
}