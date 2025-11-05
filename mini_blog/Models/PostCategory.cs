using System;

namespace mini_blog.Models;

public class PostCategory
{
    public int PostId { get; set; }
    public Posts Post { get; set; } = null!;

    public int CategoryId { get; set; }
    public Categories Category { get; set; } = null!;
}
