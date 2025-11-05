using System;
using System.ComponentModel.DataAnnotations;

namespace mini_blog.Models;

public class User
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = "User"; // "Admin" for superuser

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comments> Comments { get; set; } = new List<Comments>();
}
