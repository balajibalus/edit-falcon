using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
   public class Roles
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
