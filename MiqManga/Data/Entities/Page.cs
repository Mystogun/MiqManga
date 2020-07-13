using System;
using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Entities
{
    public class Page
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsDeleted { get; set; }

        [MaxLength(255)] public string Path { get; set; }
    }
}