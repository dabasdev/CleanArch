using MediatR;

namespace CleanArch.Application.Features.Posts.Commands.DeletePost;

public class DeletePostCommand : IRequest
{
    public Guid Id { get; set; }
}