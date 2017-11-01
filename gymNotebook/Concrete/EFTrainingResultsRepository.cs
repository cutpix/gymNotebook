using gymNotebook.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gymNotebook.ViewModels;
using gymNotebook.Models;

namespace gymNotebook.Concrete
{
    public class EFTrainingResultsRepository : ITrainingResultsRepository
    {
        public TrainingContext db = new TrainingContext();

        public TrainingResultsViewModel GetResults(int exerciseID, DateTime? dateStart, DateTime? dateEnd)
        {
            if(dateEnd == null)
            {
                dateEnd = DateTime.Now;
            }
            if(dateStart == null)
            {
                dateStart = DateTime.MinValue;
            }
            var results = db.TrainingResults.Where(a => a.ExerciseID == exerciseID && a.Datetime <= dateStart && a.Datetime >= dateEnd).ToList();

            var vm = new TrainingResultsViewModel
            {
                TrainingResults = results
            };

            return vm;
        }

        public void SaveResult(TrainingResult result)
        {
            if (result.ResultID == 0)
            {
                db.TrainingResults.Add(result);
            }
            else
            {
                TrainingResult dbEntry = db.TrainingResults.Find(result.ResultID);
                if (dbEntry != null)
                {
                    //Override trainnig results
                    dbEntry.Repetitions = result.Repetitions;
                    dbEntry.NumberSeries = result.NumberSeries;
                    dbEntry.Comments = result.Comments;
                    dbEntry.Weigth = result.Weigth;
                }
            }
            db.SaveChanges();
        }
    }
}