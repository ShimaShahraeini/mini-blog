using System;
using System.ComponentModel.DataAnnotations;

namespace mini_blog.Models;

public class Users
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    public ICollection<Posts> Posts { get; set; } = new List<Posts>();
    public ICollection<Comments> Comments { get; set; } = new List<Comments>();
}
