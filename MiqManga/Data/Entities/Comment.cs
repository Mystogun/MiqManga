using System;
using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsDeleted { get; set; }

        public User Owner { get; set; }

        [MaxLength(1024)] public string Content { get; set; }
        public byte? IsSpoiler { get; set; }

        public long ParentId { get; set; }
        public ParentType ParentType { get; set; }
    }
}