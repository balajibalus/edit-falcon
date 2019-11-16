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
    [Authorize(Roles = SD.AdminEndUser + "," +SD.MedicalEndUser)]
    [Area("Admin")]
    public class MedicalDataController : Controller
    {
        private readonly IMedicalDataRepository _db;
        private readonly ISettingRepository _repository;
        private readonly HostingEnvironment _hostingEnvironment;
        [BindProperty]
        public MedicalDataViewModel MedicalDataVM { get; set; }
        public MedicalDataController(IMedicalDataRepository db, ISettingRepository repository, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
            MedicalDataVM = new MedicalDataViewModel()
            {
                Diseases = _repository.GetDiseases().ToList(),
                MedicalData = new MedicalData()
            };
        }
        [HttpGet]
        public IActionResult Data()
        {
            var data = _db.GetData();
            return new JsonResult(data);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _db.GetData();

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(MedicalDataVM);
        }
        [HttpPost]
        public IActionResult Create(MedicalData medical)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (MedicalDataVM.MedicalData.Image != null)
            {
                var attachment = Path.Combine(webRootPath, SD.ImageFolder);
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var extenstion = Path.GetExtension(MedicalDataVM.MedicalData.Image.FileName);
                using (var filestram = new FileStream(Path.Combine(attachment, fileName + extenstion), FileMode.Create))
                {
                    MedicalDataVM.MedicalData.Image.CopyTo(filestram);
                    MedicalDataVM.MedicalData.Attachment = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                }
            }
            _db.AddMedicalData(MedicalDataVM.MedicalData);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            MedicalDataVM.MedicalData = _db.GetDataById(id);

                return View(MedicalDataVM);
          
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
          MedicalDataVM.MedicalData= _db.GetDataById(id);
            
            return View(MedicalDataVM);
        }
        [HttpPost]
        public IActionResult Edit(int id,MedicalData medical)
        {
           // MedicalDataVM.MedicalData = _db.GetDataById(id);
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
              if (MedicalDataVM.MedicalData.Image != null)
                {
                    var attachment = Path.Combine(webRootPath, SD.ImageFolder);
                    var fileName = Guid.NewGuid().ToString().Replace("-", "");
                    var extenstion = Path.GetExtension(MedicalDataVM.MedicalData.Image.FileName);
                    using (var filestram = new FileStream(Path.Combine(attachment, fileName + extenstion), FileMode.Create))
                    {
                        MedicalDataVM.MedicalData.Image.CopyTo(filestram);
                        MedicalDataVM.MedicalData.Attachment = @"\" + SD.ImageFolder + @"\" + fileName + extenstion;
                    }
                }
                _db.EditMedicalDate(MedicalDataVM.MedicalData);
            return RedirectToAction(nameof(Index));
        }

    }
}