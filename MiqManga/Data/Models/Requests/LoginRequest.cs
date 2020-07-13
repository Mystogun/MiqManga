using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Models.Requests
{
    public class LoginRequest
    {
        [MinLength(4), MaxLength(50)] public string Username { get; set; }

        [MinLength(8)] public string Password { get; set; }
    }
}