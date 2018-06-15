﻿using NEPATechDotnetCoreMVC.Models.MockUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Models.MemberProfile
{
    public class MemberProfile
    {
        [Required]
        public int MemberProfileId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Biography { get; set; }
        public DateTime LastActive { get; set; }
        public string ImageUrl { get; set; }
    }
}
