using CleanArch.Domain;

namespace CleanArch.Application.Contracts;

public interface IPostRepository : IAsyncRepository<Post>
{
    Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory);
    Task<Post> GetPostByIdAsync(Guid id, bool includeCategory);
}