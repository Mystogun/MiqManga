﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MiqManga.Data.Entities
{
    public class ParentType
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte? IsDeleted { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }

    }
}