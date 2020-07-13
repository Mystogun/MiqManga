using System;
using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Entities
{
    public class User
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsDeleted { get; set; }

        [MinLength(4), MaxLength(50)] public string Username { get; set; }

        [MaxLength(50)] public string Email { get; set; }

        [MaxLength(2048)] public string PasswordHash { get; set; }
        [MaxLength(2048)] public string PasswordSalt { get; set; }

        public byte Role { get; set; }

        [MaxLength(255)] public string AvatarPath { get; set; }
    }
}