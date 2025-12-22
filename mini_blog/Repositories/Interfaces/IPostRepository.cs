using mini_blog.Models;

namespace mini_blog.Repositories.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post?> GetPostByIdAsync(int id);

    Task<IEnumerable<Post>> GetPostsByCategoryAsync(string categoryName);
    Task<IEnumerable<Post>> GetPostsByAuthorAsync(string authorUsername);

    Task<IEnumerable<Category>> GetCategoriesByPostIdAsync(int postId);

    void AddPost(Post post);
    void DeletePost(Post post);

}
