using Microsoft.EntityFrameworkCore;
using mini_blog.Data;
using mini_blog.Models;
using mini_blog.Repositories.Interfaces;

namespace mini_blog.Repositories.Implementations;

public class PostRepository : IPostRepository
{
    private readonly BlogContext _context;
    public PostRepository(BlogContext context)
    {
        _context = context;
    }
    
    public void AddPost(Post post)
    {
        _context.Posts.Add(post);
    }

    public void DeletePost(Post post)
    {
        _context.Posts.Remove(post);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _context.Posts
            .AsNoTracking() // Read-only query; tracking disabled to reduce memory overhead
            .ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesByPostIdAsync(int postId)
    {
        return await _context.PostCategories
            .AsNoTracking() //read-only ==  untracked
            .Where(pc => pc.PostId == postId)
            .Select(pc => pc.Category)
            .ToListAsync();
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        //we should track this because we may update or delete it later
        return await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Post>> GetPostsByAuthorAsync(string authorUsername)
    {
        return await _context.Posts
            .AsNoTracking() //read-only ==  untracked
            .Where(p => p.Author.Username == authorUsername)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(string categoryName)
    {
        return await _context.Posts
            .AsNoTracking() //read-only ==  untracked
            .Where(p => p.PostCategories.Any(pc => pc.Category.Name == categoryName))
            .ToListAsync();
    }

}
