using MediatR;

namespace CleanArch.Application.Features.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}