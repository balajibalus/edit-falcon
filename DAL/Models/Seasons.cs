using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
   public class Seasons
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
