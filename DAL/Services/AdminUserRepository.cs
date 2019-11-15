using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;

namespace DAL.Services
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly ApplicationDbContext _db;
        public AdminUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public void DeleteUser(ApplicationUser user)
        {
            var applicationUser = _db.ApplicationUser.Where(a => a.Id == user.Id).FirstOrDefault();
            applicationUser.LockoutEnd = DateTime.Now.AddYears(100);
            _db.SaveChanges();
        }

        public void EditUser(ApplicationUser user)
        {
            var applicationUser = _db.ApplicationUser.Where(a => a.Id == user.Id).FirstOrDefault();
            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.PhoneNumber = user.PhoneNumber;
            _db.SaveChanges();

        }

        public List<ApplicationUser> GetUser()
        {
            return _db.ApplicationUser.ToList();
        }

        public ApplicationUser GetUserById(string id)
        {
            return _db.ApplicationUser.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
