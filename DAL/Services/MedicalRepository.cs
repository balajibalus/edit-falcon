using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;
using DAL.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class MedicalRepository : IMedicalDataRepository
    {
        private readonly ApplicationDbContext _db;
        public MedicalRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public void AddMedicalData(MedicalData medicalData)
        {
            if (medicalData != null)
            {
                MedicalData data = new MedicalData
                {
                    RingNumber = medicalData.RingNumber,
                    VisitDate = medicalData.VisitDate,
                    DiseaseId = medicalData.DiseaseId,
                    Medicine = medicalData.Medicine,
                    Attachment = medicalData.Attachment,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    CreatedBy = medicalData.CreatedBy,
                    UpdatedBy = medicalData.UpdatedBy
                };
                _db.MedicalData.Add(data);
                _db.SaveChanges();
            }
        }

        public void EditMedicalDate(MedicalData medicalData)
        {


            var data = _db.MedicalData.Where(a => a.Id == medicalData.Id).FirstOrDefault();
            if (data != null)
            {
                data.RingNumber = medicalData.RingNumber;
                data.VisitDate = medicalData.VisitDate;
                data.DiseaseId = medicalData.DiseaseId;
                data.Medicine = medicalData.Medicine;
                data.Attachment = medicalData.Attachment;
                data.UpdatedOn = DateTime.Now;
                data.UpdatedBy = medicalData.UpdatedBy;
            }
                _db.SaveChanges();
            
          
        }

        public List<MedicalData> GetData()
        {
            var medicalData = _db.MedicalData.Include(a => a.Disease);
            return medicalData.ToList();
        }

        public MedicalData GetDataById(int id)
        {
            return _db.MedicalData.Include(m => m.Disease).FirstOrDefault(m => m.Id == id);
        }
    }
}
