using CleanArch.Domain;

namespace CleanArch.Application.Dto.PostDtos;

public class PostsListForViewDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public Category Category { get; set; } = null!;
}