using System;
using System.ComponentModel.DataAnnotations;

namespace mini_blog.Models;

public class Comments
{
    public int Id { get; set; }

    [Required, MaxLength(1000)]
    public string Content { get; set; } = "";

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int PostId { get; set; }
    public Posts Post { get; set; } = null!;

    public int AuthorId { get; set; }
    public Users Author { get; set; } = null!;
}
