using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;
using DAL.Models.ViewModel;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class FalconRepository : IFalconRepository
    {
        private readonly ApplicationDbContext _db;

        public FalconRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public List<NewFalcon> GetFalcons()
        {
            return _db.NewFalcon.Include(a => a.Species).Include(a => a.ScientificName).Include(a => a.Gender).Include(a => a.Status).Include(a => a.Colors)
                .Include(a => a.Seasons).ToList();

        }

        public void AddFalcon(NewFalcon falcon)
        {
            if (falcon != null)
            {
                NewFalcon falcons = new NewFalcon
                {
                    RingNumber = falcon.RingNumber,
                    ChipNumber = falcon.ChipNumber,
                    FalconTypeId = falcon.FalconTypeId,
                    NameTypeId = falcon.NameTypeId,
                    GenderId = falcon.GenderId,
                    StatusId = falcon.StatusId,
                    ColorId = falcon.ColorId,
                    Width = falcon.Width,
                    Length = falcon.Length,
                    Weight = falcon.Weight,
                    SeasonId = falcon.SeasonId,
                    GiftedTo = falcon.GiftedTo,
                    FrontImage = falcon.FrontImage,
                    BackImage = falcon.BackImage,
                    Notes = falcon.Notes,
                    Documents = falcon.Documents,
                    CreatedOn = DateTime.Now,
                    CreatedBy = falcon.CreatedBy,
                    UpdatedBy = falcon.UpdatedBy
                };
                _db.NewFalcon.Add(falcons);
                _db.SaveChanges();

            }

        }

        public NewFalcon GetFalcon(int id)
        {
            return _db.NewFalcon.Include(a => a.Species).Include(a => a.ScientificName).Include(a => a.Gender)
                .Include(a => a.Status).Include(a => a.Colors).Include(a => a.Seasons).FirstOrDefault(m => m.Id == id);

        }

        public void EditFalcon(NewFalcon falcon)
        {
            var _falcon = _db.NewFalcon.Include(a => a.Species).Include(a => a.ScientificName).Include(a => a.Gender)
                 .Include(a => a.Status).Include(a => a.Colors).Include(a => a.Seasons).FirstOrDefault(m => m.Id == falcon.Id);
            if (_falcon != null)
            {
                _falcon.RingNumber = falcon.RingNumber;
                _falcon.ChipNumber = falcon.ChipNumber;
                _falcon.FalconTypeId = falcon.FalconTypeId;
                _falcon.NameTypeId = falcon.NameTypeId;
                _falcon.GenderId = falcon.GenderId;
                _falcon.StatusId = falcon.StatusId;
                _falcon.ColorId = falcon.ColorId;
                _falcon.Width = falcon.Width;
                _falcon.Length = falcon.Length;
                _falcon.Weight = falcon.Weight;
                _falcon.SeasonId = falcon.SeasonId;
                _falcon.GiftedTo = falcon.GiftedTo;
                _falcon.FrontImage = falcon.FrontImage;
                _falcon.BackImage = falcon.BackImage;
                _falcon.Notes = falcon.Notes;
                _falcon.Documents = falcon.Documents;
                _falcon.UpdatedOn = DateTime.Now;
                            }
            _db.NewFalcon.Update(_falcon);
            _db.SaveChanges();
        }
    }
}
