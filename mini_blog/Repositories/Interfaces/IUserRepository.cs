using mini_blog.Models;

namespace mini_blog.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByUsernameAsync(string username);
    void AddUser(User user);
    void DeleteUser(User user);
}
