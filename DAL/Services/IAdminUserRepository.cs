using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public interface IAdminUserRepository
    {
        List<ApplicationUser> GetUser();
        ApplicationUser GetUserById(string id);
        void EditUser(ApplicationUser user);
        void DeleteUser(ApplicationUser user);
    }
}
