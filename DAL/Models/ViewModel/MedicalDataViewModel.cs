using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ViewModel
{
   public class MedicalDataViewModel
    {
        public MedicalData MedicalData { get; set; }
        public IEnumerable<Disease> Diseases { get; set; }
    }
}
