using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Entities
{
    public class Chapter
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsDeleted { get; set; }

        [MaxLength(256)] public string Path { get; set; }

        public List<Page> Pages { get; set; }
        public List<Comment> Comments { get; set; }
    }
}