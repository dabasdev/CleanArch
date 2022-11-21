namespace CleanArch.Domain;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Post> Blogs { get; set; } = null!;
}