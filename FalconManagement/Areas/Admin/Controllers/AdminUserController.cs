using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using DAL.Services;
using DAL.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalconManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser)]
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private readonly IAdminUserRepository _db;
        public AdminUserController(IAdminUserRepository db)
        {
            _db = db;

        }
        [HttpGet]
        public IActionResult data()
        {
            var data = _db.GetUser();
            return new JsonResult(data);
        }


        public IActionResult Index()
        {
            return View(_db.GetUser().ToList());
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            var user = _db.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(string id, ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                _db.EditUser(applicationUser);
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            var user = _db.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationUser user)
        {
            _db.DeleteUser(user);
            return RedirectToAction(nameof(Index));


        }
    }
}