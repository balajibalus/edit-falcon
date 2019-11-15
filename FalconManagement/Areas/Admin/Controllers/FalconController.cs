using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Models.ViewModel;
using DAL.Services;
using DAL.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace FalconManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser)]
    [Area("Admin")]
    public class FalconController : Controller
    {
        private readonly IFalconRepository _db;
        private readonly ISettingRepository _repository;
        [BindProperty]
        public FalconVM FalconVModel { get; set; }
        private readonly HostingEnvironment _hostingEnvironment;
        public FalconController(IFalconRepository db, ISettingRepository repository, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
            FalconVModel = new FalconVM()
            {
                Species = _repository.GetSpecies().ToList(),
                ScientificNames = _repository.GetNames().ToList(),
                Gender = _repository.Gender().ToList(),
                Status = _repository.GetStatuses().ToList(),
                Colors = _repository.GetColors().ToList(),
                Seasons = _repository.GetSeasons().ToList(),
                NewFalcon = new NewFalcon()
            };
        }
        [HttpGet]
        public IActionResult data()
        {
            var data = _db.GetFalcons();
            return new JsonResult(data);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(FalconVModel);
        }
        [HttpPost]
        public IActionResult Create(NewFalcon addFalcon)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (FalconVModel.NewFalcon.FrontImg != null)
            {
                var frontPath = Path.Combine(webRootPath, SD.ImageFolder);
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var extenstion = Path.GetExtension(FalconVModel.NewFalcon.FrontImg.FileName);
                using (var filestram = new FileStream(Path.Combine(frontPath, fileName + extenstion), FileMode.Create))
                {
                    FalconVModel.NewFalcon.FrontImg.CopyTo(filestram);
                    FalconVModel.NewFalcon.FrontImage = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                }
            }
            if (FalconVModel.NewFalcon.BackImg != null)
            {
                var frontPath = Path.Combine(webRootPath, SD.ImageFolder);
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var extenstion = Path.GetExtension(FalconVModel.NewFalcon.BackImg.FileName);
                using (var filestram = new FileStream(Path.Combine(frontPath, fileName + extenstion), FileMode.Create))
                {
                    FalconVModel.NewFalcon.BackImg.CopyTo(filestram);
                    FalconVModel.NewFalcon.BackImage = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                }
            }
            if (FalconVModel.NewFalcon.DocumentImg != null)
            {
                var frontPath = Path.Combine(webRootPath, SD.ImageFolder);
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var extenstion = Path.GetExtension(FalconVModel.NewFalcon.DocumentImg.FileName);
                using (var filestram = new FileStream(Path.Combine(frontPath, fileName + extenstion), FileMode.Create))
                {
                    FalconVModel.NewFalcon.DocumentImg.CopyTo(filestram);
                    FalconVModel.NewFalcon.Documents = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                }
            }

            _db.AddFalcon(FalconVModel.NewFalcon);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(_db.GetFalcon(id));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
                FalconVModel.NewFalcon = _db.GetFalcon(id);

                return View(FalconVModel);
            
        }
        [HttpPost]
        public IActionResult Edit(NewFalcon newFalcon)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (FalconVModel.NewFalcon.FrontImg != null)
            {
                var frontPath = Path.Combine(webRootPath, SD.ImageFolder);
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var extenstion = Path.GetExtension(FalconVModel.NewFalcon.FrontImg.FileName);
                using (var filestram = new FileStream(Path.Combine(frontPath, fileName + extenstion), FileMode.Create))
                {
                    FalconVModel.NewFalcon.FrontImg.CopyTo(filestram);
                    FalconVModel.NewFalcon.FrontImage = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                }
            }
            if (FalconVModel.NewFalcon.BackImg != null)
            {
                var frontPath = Path.Combine(webRootPath, SD.ImageFolder);
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var extenstion = Path.GetExtension(FalconVModel.NewFalcon.BackImg.FileName);
                using (var filestram = new FileStream(Path.Combine(frontPath, fileName + extenstion), FileMode.Create))
                {
                    FalconVModel.NewFalcon.BackImg.CopyTo(filestram);
                    FalconVModel.NewFalcon.BackImage = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                }
            }
            if (FalconVModel.NewFalcon.DocumentImg != null)
            {
                var frontPath = Path.Combine(webRootPath, SD.ImageFolder);
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var extenstion = Path.GetExtension(FalconVModel.NewFalcon.DocumentImg.FileName);
                using (var filestram = new FileStream(Path.Combine(frontPath, fileName + extenstion), FileMode.Create))
                {
                    FalconVModel.NewFalcon.DocumentImg.CopyTo(filestram);
                    FalconVModel.NewFalcon.Documents = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                }
            }

            _db.EditFalcon(FalconVModel.NewFalcon);
            return RedirectToAction(nameof(Index));
        }
    }
}