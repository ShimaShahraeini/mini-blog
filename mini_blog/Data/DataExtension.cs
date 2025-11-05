using Microsoft.EntityFrameworkCore;

namespace mini_blog.Data;

public static class DataExtension
{
    // Apply all pending migrations
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

        try
        {
            await dbContext.Database.MigrateAsync();
            Console.WriteLine("Database migrated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Migration failed: {ex.Message}");
            throw;
        }
    }

    // Seed the database AFTER migrations
    public static async Task SeedDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

        try
        {
            await DbInitializer.SeedAsync(dbContext);
            Console.WriteLine("Database seeding completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Seeding failed: {ex.Message}");
            throw;
        }
    }
}
