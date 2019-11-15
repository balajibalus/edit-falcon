using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
   public  class TrainingHistory
    {
        public int Id { get; set; }
        [Required]
        public string RingNumber { get; set; }
        public string Weight { get; set; }
        public string AirplaneTrainingSpeed { get; set; }
        public string AirplaneTrainingDistane { get; set; }
        public string AirplaneTrainingTime { get; set; }
        public string HubaraTraining { get; set; }
        public string HubaraHumality { get; set; }
        public DateTime Timinings { get; set; }
        public string Data { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
