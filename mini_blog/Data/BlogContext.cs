using mini_blog.Models;
using Microsoft.EntityFrameworkCore;

namespace mini_blog.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<PostCategory> PostCategories { get; set; } = null!;

    //lives inside DbContext, for Explicitly configuring how EF should map C# classes to database tables.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //calls the base DbContext version

        modelBuilder.Entity<PostCategory>() //configure the entity called PostCategory
            .HasKey(pc => new { pc.PostId, pc.CategoryId }); //This entity has a composite primary key made up of both PostId and CategoryId

        modelBuilder.Entity<PostCategory>()
            .HasOne(pc => pc.Post)  //Each PostCategory row links to one Post.
            .WithMany(p => p.PostCategories)    //Each Post can be linked to many PostCategory rows.
            .HasForeignKey(pc => pc.PostId);    //The column in PostCategory that points to Post is PostId

        modelBuilder.Entity<PostCategory>() //dose same as post for category
            .HasOne(pc => pc.Category)  //Each PostCategory row also links to one Category.
            .WithMany(c => c.PostCategories)    //Each Category can be linked to many PostCategory rows
            .HasForeignKey(pc => pc.CategoryId);    //The column in PostCategory that points to Category is CategoryId
    }

}
