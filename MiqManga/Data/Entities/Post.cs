using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsDeleted { get; set; }

        [MaxLength(255)] public string Title { get; set; }
        [MaxLength(1024)] public string Description { get; set; }
        [MaxLength(255)] public string PosterPath { get; set; }
        [MaxLength(255)] public string CoverPath { get; set; }
        public double? Rating { get; set; }
        public byte? Language { get; set; }

        public User Owner { get; set; }
        public PostType PostType { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Comment> Comments { get; set; }
    }
}