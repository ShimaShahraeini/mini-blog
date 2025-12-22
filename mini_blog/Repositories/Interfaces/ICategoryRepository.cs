using mini_blog.Models;

namespace mini_blog.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category?> GetCategoryByNameAsync(string name);
    void AddCategory(Category category);
    void DeleteCategory(Category category);    
}
