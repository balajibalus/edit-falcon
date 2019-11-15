using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Services;
using DAL.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.Traineeenduser)]
    [Area("Admin")]
    public class TrainingHistoryController : Controller
    {
        private readonly ITrainingRepository _db;
        public TrainingHistoryController(ITrainingRepository db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult data()
        {
            var data = _db.GetData();
            return new JsonResult(data);
        }


        public IActionResult Index()
        {
            return View(_db.GetData());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TrainingHistory history)
        {
            if(history!=null)
            {
                _db.AddTrainingHistory(history);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = "Error";
            return View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_db.GetDataById(id));
        }
        [HttpPost]
        public IActionResult Edit(int id ,TrainingHistory history)
        {
            if (history != null)
            {
                _db.EditTrainingHistory(history);
            return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = "Data Not Updated";
            return View("Edit");
        }
    }
}