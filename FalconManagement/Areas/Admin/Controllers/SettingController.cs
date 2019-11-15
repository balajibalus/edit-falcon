using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Services;
using DAL.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic;

namespace FalconManagement.Areas.Admin.Controllers
{
   //[Authorize(Roles=SD.AdminEndUser)]
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingRepository _db;

       

        public SettingController(ISettingRepository db)
        {
            _db = db;
        }

        #region Color
        [HttpGet]
        public IActionResult Colors()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Data()
        {
            var colors = _db.GetColors().ToList();
            return new JsonResult(colors);

        }

       
        [HttpGet]
        public IActionResult Deleted(int id)
        {
            var clr = _db.GetColor(id);
            return View(clr);
        }
        [HttpPost]
        public IActionResult Deleted(Colors colors)
        {
            _db.Deletes(colors);
            return RedirectToAction(nameof(Colors));
        }
       
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Colors colors)
        {
            if (ModelState.IsValid)
            {
                _db.AddColor(colors);

                return RedirectToAction(nameof(Colors));
            }
            return View(colors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_db.GetColor(id));

        }
        [HttpPost]
        public IActionResult Edit(int id, Colors colors)
        {
            if (id != colors.Id)
            {
                return ViewBag.Message = "Invalid Id";
            }
            _db.EditColor(colors);
            return RedirectToAction(nameof(Colors));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_db.GetColor(id));

        }
        #endregion

        #region Country
        [HttpGet]
        public IActionResult CountryData()
        {
            var countries = _db.Countries();
            return new JsonResult(countries);

        }

        [HttpGet]
        public IActionResult Country()
        {
            return View(_db.Countries());
        }
        [HttpGet]
        public IActionResult AddCountry()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.AddCountry(country);

                return RedirectToAction(nameof(Country));
            }
            return View(country);
        }
        [HttpGet]
        public IActionResult EditCountry(int id)
        {
            return View(_db.GetCountry(id));

        }
        [HttpPost]
        public IActionResult EditCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return ViewBag.Message = "Invalid Id";
            }
            _db.EditCountry(country);
            return RedirectToAction(nameof(Country));
        }

        [HttpGet]
        public IActionResult CountryDetails(int id)
        {
            return View(_db.GetCountry(id));

        }
        [HttpGet]
        public IActionResult CountryDelete(int id)
        {
            var country = _db.GetCountry(id);
            return View(country);
        }
        [HttpPost]
        public IActionResult CountryDelete(Country country)
        {
            _db.DeleteCountry(country);

            return RedirectToAction(nameof(Country));
        }
        #endregion

        #region Status
        [HttpGet]
        public IActionResult StatusData()
        {
            var _status = _db.GetStatuses();
            return new JsonResult(_status);

        }

        [HttpGet]
        public IActionResult Status()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStatus()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                _db.AddStatus(status);

                return RedirectToAction(nameof(Status));
            }
            return View(status);
        }
        [HttpGet]
        public IActionResult EditStatus(int id)
        {
            return View(_db.GetStatus(id));

        }
        [HttpPost]
        public IActionResult EditStatus(int id, Status status)
        {
            if (id != status.Id)
            {
                return ViewBag.Message = "Invalid Id";
            }
            _db.EditStatus(status);
            return RedirectToAction(nameof(Status));
        }
        [HttpGet]
        public IActionResult StatusDetails(int id)
        {
            return View(_db.GetStatus(id));

        }
        [HttpGet]
        public IActionResult StatusDelete(int id)
        {
            var status = _db.GetStatus(id);
            return View(status);
        }
        [HttpPost]
        public IActionResult StatusDelete(Status status)
        {
            _db.DeleteStatus(status);

            return RedirectToAction(nameof(Status));
        }


        #endregion

        #region Disease
        [HttpGet]
        public IActionResult DiseaseData()
        {
            var data = _db.GetDiseases();
            return new JsonResult(data);

        }

        [HttpGet]
        public IActionResult GetDisease()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddDisease()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddDisease(Disease disease)
        {
            if (ModelState.IsValid)
            {

                _db.AddDisease(disease);

                return RedirectToAction(nameof(GetDisease));
            }
            return View(disease);
        }
        [HttpGet]
        public IActionResult EditDisease(int id)
        {
            return View(_db.GetDisease(id));

        }
        [HttpPost]
        public IActionResult EditDisease(int id, Disease disease)
        {
            if (id != disease.Id)
            {
                return ViewBag.Message = "Invalid Id";
            }
            _db.EditDisease(disease);
            return RedirectToAction(nameof(GetDisease));
        }
        [HttpGet]
        public IActionResult DiseaseDetails(int id)
        {
            return View(_db.GetDisease(id));

        }
        [HttpGet]
        public IActionResult DiseaseDelete(int id)
        {
            var disease = _db.GetDisease(id);
            return View(disease);
        }
        [HttpPost]
        public IActionResult DiseaseDelete(Disease disease)
        {
            _db.DeleteDisease(disease);

            return RedirectToAction(nameof(GetDisease));
        }

        #endregion

        #region Scientifi Name

        [HttpGet]
        public IActionResult NameData()
        {
            var data = _db.GetNames();
            return new JsonResult(data);

        }
        [HttpGet]
        public IActionResult GetScientificNames()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddScientificNames()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddScientificNames(ScientificName scientific)
        {
            _db.AddName(scientific);
            return RedirectToAction(nameof(GetScientificNames));
        }
        public IActionResult EditName(int id)
        {
            return View(_db.GetScientific(id));

        }
        [HttpPost]
        public IActionResult EditName(int id, ScientificName scientific)
        {
            if (id != scientific.Id)
            {
                return ViewBag.Message = "Invalid Id";
            }
            _db.EditName(scientific);
            return RedirectToAction(nameof(GetScientificNames));
        }
        [HttpGet]
        public IActionResult NameDetails(int id)
        {
            return View(_db.GetScientific(id));

        }
        [HttpGet]
        public IActionResult NameDelete(int id)
        {
            var name = _db.GetScientific(id);
            return View(name);
        }
        [HttpPost]
        public IActionResult NameDelete(ScientificName scientific)
        {
            _db.DeleteScientificName(scientific);

            return RedirectToAction(nameof(GetScientificNames));
        }
        #endregion

        #region Season
        [HttpGet]
        public IActionResult SeasonData()
        {
            var data = _db.GetSeasons();
            return new JsonResult(data);

        }
        [HttpGet]
        public IActionResult GetSeasons()
        {

            return View(_db.GetSeasons());
        }
        [HttpGet]
        public IActionResult AddSeason()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddSeason(Seasons seasons)
        {
            _db.AddSeasons(seasons);
            return RedirectToAction(nameof(GetSeasons));
        }
       
        [HttpGet]
        public IActionResult EditSeasons(int id)
        {
            return View(_db.GetSeason(id));

        }
        [HttpPost]
        public IActionResult EditSeasons(int id, Seasons seasons)
        {
            if (id != seasons.Id)
            {
                return ViewBag.Message = "Invalid Id";
            }
            _db.EditSeason(seasons);
            return RedirectToAction(nameof(GetSeasons));
        }
        [HttpGet]
        public IActionResult SeasonsDetails(int id)
        {
            return View(_db.GetSeason(id));

        }
        [HttpGet]
        public IActionResult SeasonDelete(int id)
        {
            var season = _db.GetSeason(id);
            return View(season);
        }
        [HttpPost]
        public IActionResult SeasonDelete(Seasons seasons)
        {
            _db.DeleteSeason(seasons);

            return RedirectToAction(nameof(GetSeasons));
        }

        //[HttpGet]
        //public IActionResult SeasonsDetails(int id)
        //{
        //    return View(_db.GetSeason(id));

        //}
        [HttpGet]
        public IActionResult Set(int id)
        {
            var season = _db.GetSeason(id);
            _db.Default(season);
            return RedirectToAction(nameof(GetSeasons));
        }


        #endregion

        #region Species
        [HttpGet]
        public IActionResult SpeciesData()
        {
            var data = _db.GetSpecies();
            return new JsonResult(data);

        }

        [HttpGet]
        public IActionResult Species()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetSpecies()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddSpecies()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddSpecies(Species species)
        {
            _db.AddSpecies(species);

            return RedirectToAction(nameof(Species));
        }
        [HttpGet]
        public IActionResult EditSpecies(int id)
        {
            return View(_db.GetSpecie(id));

        }
        [HttpPost]
        public IActionResult EditSpecies(int id, Species species)
        {
            if (id != species.Id)
            {
                return ViewBag.Message = "Invalid Id";
            }
            _db.EditSpecie(species);
            return RedirectToAction(nameof(Species));
        }
        [HttpGet]
        public IActionResult SpeciesDetails(int id)
        {
            return View(_db.GetSpecie(id));

        }
        [HttpGet]
        public IActionResult SpeciesDelete(int id)
        {
            var species = _db.GetSpecie(id);
            return View(species);
        }
        [HttpPost]
        public IActionResult SpeciesDelete(Species species)
        {
            _db.DeleteSpecies(species);

            return RedirectToAction(nameof(Species));
        }
        #endregion
    }
}
