using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
   public class NewFalcon
    {
        public int Id { get; set; }
        [Required]
        public string RingNumber { get; set; }
        [Required]
        public string ChipNumber { get; set; }
        [Required]
        [Display(Name = "Falcon Species")]
        public int FalconTypeId { get; set; }
        [ForeignKey("FalconTypeId")]
        public virtual Species Species { get; set; }

        [Required]
        [Display(Name = "Scientific Name")]
        public int NameTypeId { get; set; }
        [ForeignKey("NameTypeId")]
        public virtual ScientificName ScientificName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [Required]
        [Display(Name = "Color")]
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual Colors Colors { get; set; }

        public string Width { get; set; }
        public string Length { get; set; }
        public string Weight { get; set; }

        [Required]
        [Display(Name = "Season")]
        public int SeasonId { get; set; }
        [ForeignKey("SeasonId")]
        public virtual Seasons Seasons { get; set; }



        public string GiftedTo { get; set; }
        public string FrontImage { get; set; }
        public string BackImage { get; set; }
        public string Notes { get; set; }
        public string Documents { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [NotMapped]
        public IFormFile FrontImg { get; set; }
        [NotMapped]
        public IFormFile BackImg { get; set; }
        [NotMapped]
        public IFormFile DocumentImg { get; set; }
    }
}
