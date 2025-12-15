using Microsoft.EntityFrameworkCore;
using mini_blog.Models;

namespace mini_blog.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(BlogContext context, ILogger logger)
    {
        try
        {
            // Seed Admin User
            if (!await context.Users.AnyAsync(u => u.Role == "Admin"))
            {
                var admin = new User
                {
                    Username = "shima",
                    Email = "shmshahraein@gmail.com",
                    PasswordHash = "shima1234",
                    Role = "Admin"
                };
                context.Users.Add(admin);
                await context.SaveChangesAsync();
                logger.LogInformation("Admin user created.");
            }

            // Seed Categories
            if (!await context.Categories.AnyAsync())
            {
                context.Categories.AddRange(
                    new Category { Name = "Tech" },
                    new Category { Name = "Travel" },
                    new Category { Name = "Lifestyle" }
                );
                await context.SaveChangesAsync();
                logger.LogInformation("Default categories added.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error during seeding: {ex.Message}");
            throw;
        }
    }
}
