using Microsoft.EntityFrameworkCore;
using mini_blog.Data;
using mini_blog.Models;
using mini_blog.Repositories.Interfaces;

namespace mini_blog.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly BlogContext _context;
    public UserRepository(BlogContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .AsNoTracking() // Read-only query; tracking disabled to reduce memory overhead
            .FirstOrDefaultAsync(u => u.Username == username);
    }

}
