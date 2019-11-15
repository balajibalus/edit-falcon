using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
   public class MedicalData
    {
        public int Id { get; set; }
        [Required]
        public string RingNumber { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }

        [Display(Name = "Cause of Visit")]
        public int DiseaseId { get; set; }
        [ForeignKey("DiseaseId")]
        public virtual Disease Disease { get; set; }
        [Required]
        public string Medicine { get; set; }

        public string Attachment { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }



        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
