﻿using System.ComponentModel.DataAnnotations;

namespace Hospital2.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminName { get; set; }

        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }

    }
}
