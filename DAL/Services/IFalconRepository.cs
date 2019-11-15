using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public interface IFalconRepository
    {
        List<NewFalcon> GetFalcons();
        NewFalcon GetFalcon(int id);
        void AddFalcon(NewFalcon falcon);
        void EditFalcon(NewFalcon falcon);

    }
}
