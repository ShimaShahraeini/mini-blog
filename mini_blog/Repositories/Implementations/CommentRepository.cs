using Microsoft.EntityFrameworkCore;
using mini_blog.Data;
using mini_blog.Models;
using mini_blog.Repositories.Interfaces;

namespace mini_blog.Repositories.Implementations;

public class CommentRepository : ICommentRepository
{
    private readonly BlogContext _context;
    public CommentRepository(BlogContext context)
    {
        _context = context;
    }  

    public void AddComment(Comment comment)
    {
        _context.Comments.Add(comment);
    }

    public void DeleteComment(Comment comment)
    {
        _context.Comments.Remove(comment);
    }

    public async Task<Comment?> GetCommentsByIdAsync(int id)
    {
        return await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _context.Comments
            .AsNoTracking() // Read-only query; tracking disabled to reduce memory overhead
            .Where(c => c.PostId == postId)
            .ToListAsync();
    }
}
