using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ViewModel
{
    public class FalconVM
    {
        public NewFalcon NewFalcon { get; set; }
        public IEnumerable<Species> Species { get; set; }
        public IEnumerable<ScientificName> ScientificNames { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<Status> Status { get; set; }
        public IEnumerable<Colors> Colors { get; set; }
        public IEnumerable<Seasons> Seasons { get; set; }
    }
}
