using System;
using System.ComponentModel.DataAnnotations;

namespace mini_blog.Models;

public class Categories
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public List<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
}
