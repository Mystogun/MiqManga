using System;
using System.Collections.Generic;

namespace MiqManga.Data.Entities
{
    public class FreeWall
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsDeleted { get; set; }

        public List<Comment> Comments { get; set; }
    }
}