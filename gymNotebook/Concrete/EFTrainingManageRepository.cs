using gymNotebook.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gymNotebook.Models;
using gymNotebook.ViewModels;

namespace gymNotebook.Concrete
{
    public class EFTrainingManageRepository : ITrainingManageRepository
    {
        public TrainingContext db = new TrainingContext();

        public IEnumerable<Training> Trainings
        {
            get { return db.Trainings; }
        }
        public ExerciseViewModel GetExercises(int SessionId)
        {
            var exercises = db.Exercises.Where(e => e.SessionID == SessionId).ToList();

            var vm = new ExerciseViewModel
            {
                Exercises = exercises
            };
            return vm;
        }
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

        public void SaveTraining(Training training)
        {
            if(training.TrainingID == 0)
            {
                db.Trainings.Add(training);
            }
            else
            {
                Training dbEntry = db.Trainings.Find(training.TrainingID);
                if(dbEntry != null)
                {
                    dbEntry.TrainingName = training.TrainingName;
                }
            }
            db.SaveChanges();
        }

        public void SaveSession(TrainingSession session)
        {
            if (session.SessionID == 0)
            {
                db.TrainingSessions.Add(session);
            }
            else
            {
                TrainingSession dbEntry = db.TrainingSessions.Find(session.SessionID);
                if (dbEntry != null)
                {
                    dbEntry.SessionName = session.SessionName;
                    dbEntry.TrainingID = session.TrainingID;
                }
            }
            db.SaveChanges();
        }

        public void SaveExercise(Exercise exercise)
        {
            if (exercise.ExerciseID == 0)
            {
                db.Exercises.Add(exercise);
            }
            else
            {
                Exercise dbEntry = db.Exercises.Find(exercise.ExerciseID);
                if (dbEntry != null)
                {
                    dbEntry.ExerciseName = exercise.ExerciseName;
                    dbEntry.Description = exercise.Description;
                    dbEntry.MusclePartID = exercise.MusclePartID;
                    dbEntry.SessionID = exercise.SessionID;
                }
            }
            db.SaveChanges();
        }

        public Training DeleteTraining(int trainingID)
        {
            Training dbTraining = db.Trainings.Find(trainingID); 
            if(dbTraining != null)
            {
                List<TrainingSession> dbSessions = db.TrainingSessions.Where(s => s.TrainingID == trainingID).ToList();
                if(dbSessions != null)
                {
                    foreach(var sesion in dbSessions)
                    {
                        db.TrainingSessions.Remove(sesion);
                        db.SaveChanges();
                    }
                }
                db.Trainings.Remove(dbTraining);
                db.SaveChanges();
            }
            return dbTraining;
        }

        public TrainingSession DeleteSession(int sessionID)
        {
            TrainingSession dbEntry = db.TrainingSessions.Find(sessionID);
            if (dbEntry != null)
            {
                db.TrainingSessions.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }

        public Exercise DeleteExercise(int exerciseID)
        {
            Exercise dbExercise = db.Exercises.Find(exerciseID);
            if (dbExercise != null)
            {
                List<TrainingResult> dbResults = db.TrainingResults.Where(r => r.ExerciseID == exerciseID).ToList();
                if(dbResults != null)
                {
                    foreach(var result in dbResults)
                    {
                        db.TrainingResults.Remove(result);
                        db.SaveChanges();
                    }
                }
                db.Exercises.Remove(dbExercise);
                db.SaveChanges();
            }
            return dbExercise;
        }
    }
}