using gymNotebook.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gymNotebook.Models;
using gymNotebook.ViewModels;

namespace gymNotebook.Concrete
{
    public class EFTrainingRepository : ITrainingRepository
    {
        private TrainingContext db = new TrainingContext();

        public TrainingViewModel GetTrainings(string UserID)
        {
            var trainings = db.Trainings.Where(a => a.UserId == UserID).ToList();

            var sessions = db.Trainings.Join(db.TrainingSessions, t => t.TrainingID, s => s.TrainingID,
                (t, s) => new { Training = t, TrainingSession = s }).Where(c => c.Training.UserId == UserID)
                .Select(s => s.TrainingSession).ToList();

            var exercises = db.Trainings.Join(db.TrainingSessions, t => t.TrainingID, s => s.TrainingID,
                (t, s) => new { Training = t, TrainingSession = s }).Where(c => c.Training.UserId == UserID)
                .Join(db.Exercises, s => s.TrainingSession.SessionID, e => e.SessionID,
                (s, e) => new { s, e }).Select(s => s.e).ToList();

            var vm = new TrainingViewModel
            {
                Trainings = trainings,
                TrainingSessions = sessions,
                Exercises = exercises
            };

            return vm;
        }
    }
}