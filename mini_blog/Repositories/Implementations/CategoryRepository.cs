using Microsoft.EntityFrameworkCore;
using mini_blog.Data;
using mini_blog.Models;
using mini_blog.Repositories.Interfaces;

namespace mini_blog.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly BlogContext _context;
    public CategoryRepository(BlogContext context)
    {
        _context = context;
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
    }

    public void DeleteCategory(Category category)
    {
        _context.Categories.Remove(category);
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        //we should track this because we may update or delete it later
        return  await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        return await _context.Categories
            .AsNoTracking() // Read-only query; tracking disabled to reduce memory overhead
            .FirstOrDefaultAsync(c => c.Name == name);
    }

}