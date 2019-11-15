using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
    public interface IMedicalDataRepository
    {
        List<MedicalData> GetData();
        MedicalData GetDataById(int id);
        void AddMedicalData(MedicalData medicalData);
        void EditMedicalDate(MedicalData medicalData);


       
    }
}
