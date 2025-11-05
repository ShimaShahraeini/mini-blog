using Microsoft.EntityFrameworkCore;
using mini_blog.Data;

var builder = WebApplication.CreateBuilder(args);

//Connect to PostgreSQL using your connection string from appsettings.json
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Automatic migration and seeding
await app.MigrateDbAsync();
await app.SeedDbAsync();

app.Run();
