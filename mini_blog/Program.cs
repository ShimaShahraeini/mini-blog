using Microsoft.EntityFrameworkCore;
using mini_blog.Data;

var builder = WebApplication.CreateBuilder(args);

//Connect to MySQL using connection string from appsettings.json
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8,0,32)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);


var app = builder.Build();

// Automatic migration and seeding
await app.MigrateDbAsync();
await app.SeedDbAsync();

app.Run();
