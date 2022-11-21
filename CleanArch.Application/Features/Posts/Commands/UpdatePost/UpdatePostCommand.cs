using MediatR;

namespace CleanArch.Application.Features.Posts.Commands.UpdatePost;

public class UpdatePostCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}