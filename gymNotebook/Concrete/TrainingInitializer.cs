using gymNotebook.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using gymNotebook.Migrations;
using System;

namespace gymNotebook.Concrete
{
    public class TrainingInitializer : MigrateDatabaseToLatestVersion<TrainingContext, Configuration>
    {
        public static void Seed(TrainingContext context)
        {
            var training = new List<Training>
            {
            new Training() { UserId = "b6b7f758-2f08-45d2-8ded-4f1670dad44b", TrainingName = "Trening Split" }
            };

            //training.ForEach(t => context.Trainings.AddOrUpdate(t));
            //context.SaveChanges();

            var session = new List<TrainingSession>
            {
                new TrainingSession(){ TrainingID = 3, SessionName = "Poniedziałek"},
                new TrainingSession(){ TrainingID = 3, SessionName = "Środa"},
                new TrainingSession(){ TrainingID = 3, SessionName = "Czwartek"}
            };

            //session.ForEach(s => context.TrainingSessions.AddOrUpdate(s));
            //context.SaveChanges();

            var muscleParts = new List<MusclePart>
            {
                new MusclePart(){ MuscleName = "Chest"},
                new MusclePart(){ MuscleName = "Back"},
                new MusclePart(){ MuscleName = "Legs"},
                new MusclePart(){ MuscleName = "Biceps"},
                new MusclePart(){ MuscleName = "Shoulders"},
                new MusclePart(){ MuscleName = "Triceps"},
                new MusclePart(){ MuscleName = "ABS"},
                new MusclePart(){ MuscleName = "Forearm"}
            };

            //muscleParts.ForEach(mp => context.MuscleParts.AddOrUpdate(mp));
            //context.SaveChanges();

            var exercises = new List<Exercise>
            {
                new Exercise(){ ExerciseName = "Dipsy", MusclePartID = 6, SessionID = 2, Description = "Pompki na poręczach"},
                new Exercise(){ ExerciseName = "Arnold Press", MusclePartID = 5, SessionID = 2, Description = "Arnoldki"},
                new Exercise(){ ExerciseName = "Cable Reverse Fly", MusclePartID = 5, SessionID = 2, Description = "Odwrotne rozpiętki"},
                new Exercise(){ ExerciseName = "Deadlift", MusclePartID = 2, SessionID = 3, Description = "Martwy ciąg klasyczny"},
                new Exercise(){ ExerciseName = "Chin Up", MusclePartID = 2, SessionID = 3, Description = "Podciąganie na drążku podchwytem"},
                new Exercise(){ ExerciseName = "Lat Pull Down", MusclePartID = 2, SessionID = 3, Description = "Ściąganie drążka wyciągu górnego w siadzie szerokim uchwytem"},
                new Exercise(){ ExerciseName = "Barbell Bench Press", MusclePartID = 1, SessionID = 1, Description = "Wyciskanie sztangi leżąc na ławce poziomej" },
                new Exercise(){ ExerciseName = "Dumbbell Flys", MusclePartID = 1, SessionID = 1, Description = "Rozpiętki ze sztangielkami leżąc na ławce poziomej" },
                new Exercise(){ ExerciseName = "Incline Bench Press", MusclePartID = 1, SessionID = 1, Description = "Wyciskanie sztangi leżąc na ławce skośnej-głową w górę"},
            };

            //exercises.ForEach(e => context.Exercises.AddOrUpdate(e));
            //context.SaveChanges();

            var results = new List<TrainingResult>
            {
                new TrainingResult(){ ExerciseID = 7, NumberSeries = 1, Repetitions = 12, Datetime = DateTime.Now, Weigth = 80},
                new TrainingResult(){ ExerciseID = 7, NumberSeries = 2, Repetitions = 10, Datetime = DateTime.Now, Weigth = 85},
                new TrainingResult(){ ExerciseID = 7, NumberSeries = 3, Repetitions = 8, Datetime = DateTime.Now, Weigth = 90},
                new TrainingResult(){ ExerciseID = 7, NumberSeries = 4, Repetitions = 6, Datetime = DateTime.Now, Weigth = 95}
            };

            //results.ForEach(tr => context.TrainingResults.AddOrUpdate(tr));
            //context.SaveChanges();

            var userData = new List<Models.UserData>
            {
                new Models.UserData() { UserId = "b6b7f758-2f08-45d2-8ded-4f1670dad44b", Name = "TestName", Surname = "TestSurname", Height = 90f,
                DateOfBirth = DateTime.ParseExact("2000-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) }
            };

            //userData.ForEach(ud => context.UserData.AddOrUpdate(ud));
            //context.SaveChanges();
        }
    }
}