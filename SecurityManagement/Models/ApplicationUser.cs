﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityManagement.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        [NotMapped]
        public override bool TwoFactorEnabled { get; set; }

        [NotMapped]
        public override string NormalizedEmail { get; set; }

        [NotMapped]
        public override string NormalizedUserName { get; set; }

        public string parent_id { get; set; }
    }
}
