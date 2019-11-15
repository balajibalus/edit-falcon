using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;

namespace DAL.Services
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _db;
        public TrainingRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool AddTrainingHistory(TrainingHistory training)
        {
            if (training != null)
            {
                
                    TrainingHistory history = new TrainingHistory
                    {
                        RingNumber = training.RingNumber,
                        Weight = training.Weight,
                        AirplaneTrainingSpeed = training.AirplaneTrainingSpeed,
                        AirplaneTrainingDistane = training.AirplaneTrainingDistane,
                        AirplaneTrainingTime = training.AirplaneTrainingTime,
                        HubaraTraining = training.HubaraTraining,
                        HubaraHumality = training.HubaraHumality,
                        Timinings = training.Timinings,
                        Data = training.Data,
                        CreatedOn = DateTime.Now
                    };
                    _db.TrainingHistory.Add(history);
                    var saved = _db.SaveChanges();
                    return saved >= 0 ? true : false;
                
            }
            return false;
        }

        public bool EditTrainingHistory(TrainingHistory training)
        {
            var data = _db.TrainingHistory.Where(a => a.Id == training.Id).FirstOrDefault();
            if (data != null)
            {
                data.RingNumber = training.RingNumber;
                data.Weight = training.Weight;
                data.AirplaneTrainingSpeed = training.AirplaneTrainingSpeed;
                data.AirplaneTrainingDistane = training.AirplaneTrainingDistane;
                data.AirplaneTrainingTime = training.AirplaneTrainingTime;
                data.HubaraTraining = training.HubaraTraining;
                data.HubaraHumality = training.HubaraHumality;
                data.Timinings = training.Timinings;
                data.Data = training.Data;
                data.UpdatedOn = DateTime.Now;
            }
            var saved = _db.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public List<TrainingHistory> GetData()
        {
            return _db.TrainingHistory.ToList();
        }

        public TrainingHistory GetDataById(int id)
        {
            return _db.TrainingHistory.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
