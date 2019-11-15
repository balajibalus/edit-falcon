using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services
{
  public  interface ITrainingRepository
    {
        List<TrainingHistory> GetData();
        TrainingHistory GetDataById(int id);
        bool AddTrainingHistory(TrainingHistory training);
        bool EditTrainingHistory(TrainingHistory training);
    }
}
