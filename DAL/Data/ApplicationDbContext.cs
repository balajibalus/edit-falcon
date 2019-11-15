using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
   public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
       public virtual DbSet<ScientificName> ScientificNames { get; set; }
        public virtual DbSet<Seasons> Seasons { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        //public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

       
        public virtual DbSet<NewFalcon> NewFalcon { get; set; }
        public virtual DbSet<MedicalData> MedicalData { get; set; }
        public virtual DbSet<TrainingHistory> TrainingHistory { get; set; }

    }

}
