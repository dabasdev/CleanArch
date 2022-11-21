using CleanArch.Application.Dto.PostDtos;
using MediatR;

namespace CleanArch.Application.Features.Posts.Queries.GetPostDetails;

public class GetPostDetailQuery : IRequest<PostDetailForViewDto>
{
    public Guid PostId { get; set; }
}