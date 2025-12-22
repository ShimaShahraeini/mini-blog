using mini_blog.Models;

namespace mini_blog.Repositories.Interfaces;

public interface ICommentRepository
{
    Task<Comment?> GetCommentsByIdAsync(int id);
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
    void AddComment(Comment comment);
    void DeleteComment(Comment comment);
}
