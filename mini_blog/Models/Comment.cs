using System;
using System.ComponentModel.DataAnnotations;

namespace mini_blog.Models;

public class Comment
{
    public int Id { get; set; }

    [Required, MaxLength(1000)]
    public string Content { get; set; } = "";

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;
}
