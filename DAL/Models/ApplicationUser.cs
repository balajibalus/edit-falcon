using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public bool IsSuperAdmin { get; set; }
        [NotMapped]
        public bool IsMedicalAdmin { get; set; }
        [NotMapped]
        public bool IsTraineeAdmin { get; set; }
    }
}
