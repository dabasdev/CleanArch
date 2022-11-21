using CleanArch.Application.Contracts;
using CleanArch.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
    {
        var allPosts = includeCategory
            ? await Context.Posts.Include(x => x.Category).ToListAsync()
            : await Context.Posts.ToListAsync();
        return allPosts;
    }

    public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
    {
        var post = includeCategory
            ? await Context.Posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id)
            : await GetByIdAsync(id);

        return post!;
    }
}