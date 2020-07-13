using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Models.Requests
{
    public class RegisterUserRequest
    {
        [MinLength(4), MaxLength(50)] public string Username { get; set; }

        [MaxLength(50)] public string Email { get; set; }

        [MinLength(8)] public string Password { get; set; }
    }
}