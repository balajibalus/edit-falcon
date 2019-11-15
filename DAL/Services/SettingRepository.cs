using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;

namespace DAL.Services
{
    public class SettingRepository : ISettingRepository
    {
        private readonly ApplicationDbContext _db;

        public SettingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Colors
        
        public List<Colors> GetColors()
        {
            
            return  _db.Colors.ToList();
        }
        public Colors GetColor(int id)
        {
            return _db.Colors.Where(c => c.Id == id).FirstOrDefault();
               
        }

        public string AddColor(Colors colors)
        {
            if (_db.Colors.Any(a => a.Name == colors.Name))
            {
                var error = "already exists";
                return error;
            }
            _db.Colors.Add(colors);
            _db.SaveChanges();
            var sucess = "Sucess";
            return sucess;

        }

        public string EditColor(Colors colors)
        {
            var newColor = _db.Colors.Where(c => c.Id == colors.Id).FirstOrDefault();
            newColor.Name = colors.Name;
            
            _db.SaveChanges();
            var sucess = "Sucess";
            return sucess;
        }
        public void Deletes(Colors colors)
        {
            _db.Colors.Remove(colors);
            _db.SaveChanges();
        }

        #endregion

        #region Country
        public List<Country> Countries()
        {
            return _db.Countries.ToList();
        }
        public Country GetCountry(int id)
        {
            return _db.Countries.Where(c => c.Id == id).FirstOrDefault();

        }

        public string AddCountry(Country country)
        {
            if (_db.Countries.Any(a => a.Name == country.Name))
            {
                var error = "already exists";
                return error;
            }
            _db.Countries.Add(country);
            _db.SaveChanges();
            var sucess = "Sucess";
            return sucess;
        }
        public void EditCountry(Country country)
        {
            var newCountry = _db.Countries.Where(c => c.Id == country.Id).FirstOrDefault();
            newCountry.Name = country.Name;

            _db.SaveChanges();
           
           
        }
        public void DeleteCountry(Country country)
        {
            _db.Countries.Remove(country);
            _db.SaveChanges();
        }
        #endregion

        #region ScientificName
        public List<ScientificName> GetNames()
        {
            return _db.ScientificNames.ToList();
        }
        public ScientificName GetScientific(int id)
        {
            return _db.ScientificNames.Where(c => c.Id == id).FirstOrDefault();

        }
        public string AddName(ScientificName scientific)
        {
            if (_db.ScientificNames.Any(a => a.Name == scientific.Name))
            {
                var error = "already exists";
                return error;
            }
            scientific.CreatedOn = DateTime.Now;
            scientific.UpdatedOn = DateTime.Now;
            _db.ScientificNames.Add(scientific);
            _db.SaveChanges();
            var sucess = "Sucess";
            return sucess;
        }
        public void EditName(ScientificName scientific)
        {
            var newName = _db.ScientificNames.Where(c => c.Id == scientific.Id).FirstOrDefault();
            newName.Name = scientific.Name;
            newName.UpdatedOn = DateTime.Now;

            _db.SaveChanges();
        }
        public void DeleteScientificName(ScientificName scientific)
        {
            _db.ScientificNames.Remove(scientific);
            _db.SaveChanges();
        }

        #endregion

        #region Seasons
        public List<Seasons> GetSeasons()
        {
            return _db.Seasons.ToList();
        }
        public Seasons GetSeason(int id)
        {
           return _db.Seasons.Where(s => s.Id == id).FirstOrDefault();
        }
        public string AddSeasons(Seasons seasons)
        {
            if (_db.Seasons.Any(a => a.Name == seasons.Name))
            {
                var error = "already exists";
                return error;
            }

            seasons.CreatedOn = DateTime.Now;
            seasons.UpdatedOn = DateTime.Now;
            _db.Seasons.Add(seasons);
            _db.SaveChanges();
            var sucess = "Sucess";
            return sucess;
        }
      
        public void EditSeason(Seasons seasons)
        {
          
                var newSeason = _db.Seasons.Where(c => c.Id == seasons.Id).FirstOrDefault();
            newSeason.Name = seasons.Name;
            newSeason.UpdatedOn = DateTime.Now;

                _db.SaveChanges();
               
            
        }

        public void DeleteSeason(Seasons seasons)
        {
            _db.Seasons.Remove(seasons);
            _db.SaveChanges();
        }

        public void Default(Seasons seasons)
        {
            var ss = _db.Seasons.Where(a => a.Id == seasons.Id).FirstOrDefault();
            ss.IsDefault = true;
            _db.SaveChanges();
            

            var details = _db.Seasons.Where(a => a.Id != seasons.Id).ToList();
            foreach (var item in details)
            {
                item.IsDefault = false;
                _db.SaveChanges();
               
            }
            
        }
        #endregion

        #region Species
        public List<Species> GetSpecies()
        {
            return _db.Species.ToList();
        }
        public Species GetSpecie(int id)
        {
            return _db.Species.Where(c => c.Id == id).FirstOrDefault();

        }
        public string AddSpecies(Species species)
        {
            if (_db.Species.Any(a => a.Name == species.Name))
            {
                var error = "already exists";
                return error;
            }
            species.CreatedOn = DateTime.Now;
            species.UpdatedOn = DateTime.Now;
            _db.Species.Add(species);
            _db.SaveChanges();
            var sucess = "Sucess";
            return sucess;
        }
        public void EditSpecie(Species species)
        {
            var newSpecie = _db.Species.Where(c => c.Id ==species.Id ).FirstOrDefault();
            newSpecie.Name = species.Name;
            newSpecie.UpdatedOn = DateTime.Now;

            _db.SaveChanges();
        }
        public void DeleteSpecies(Species species)
        {
            _db.Species.Remove(species);
            _db.SaveChanges();
        }
        #endregion

        #region Status
        public List<Status> GetStatuses()
        {
            return _db.Statuses.ToList();
        }
        public Status GetStatus(int id)
        {
            return _db.Statuses.Where(c => c.Id == id).FirstOrDefault();

        }
        public string AddStatus(Status status)
        {
            if (_db.Statuses.Any(a => a.Name == status.Name))
            {
                var error = "already exists";
                return error;
            }
            _db.Statuses.Add(status);
            _db.SaveChanges();
            var sucess = "Sucess";
            return sucess;
        }
        public void EditStatus(Status status)
        {
            var newStatus = _db.Statuses.Where(c => c.Id == status.Id).FirstOrDefault();
            newStatus.Name = status.Name;
           

            _db.SaveChanges();
        }
        public void DeleteStatus(Status status)
        {
            _db.Statuses.Remove(status);
            _db.SaveChanges();
        }
        #endregion

        #region Disease
        public List<Disease> GetDiseases()
        {
            return _db.Diseases.ToList();
        }
        public Disease GetDisease(int id)
        {
            return _db.Diseases.Where(c => c.Id == id).FirstOrDefault();

        }
        public string AddDisease(Disease disease)
        {
            if (_db.Diseases.Any(a => a.Name == disease.Name))
            {
                var errormsg = "already exists";
                return errormsg;
            }
            if (disease != null)
            {
                _db.Diseases.Add(disease);
                _db.SaveChanges();

            }
            var error = "Error";
            return error;

        }
        public void EditDisease(Disease disease)
        {
            var newDisease = _db.Diseases.Where(c => c.Id == disease.Id).FirstOrDefault();
            newDisease.Name = disease.Name;
            newDisease.UpdatedOn = DateTime.Now;


            _db.SaveChanges();
        }


       

        public void DeleteDisease(Disease disease)
        {
            _db.Remove(disease);
            _db.SaveChanges();
        }

        public List<Gender> Gender()
        {
            return _db.Gender.ToList();
        }



        #endregion
    }
}
