using gymNotebook.Models;
using gymNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gymNotebook.Abstract
{
    public interface ITrainingManageRepository
    {
        IEnumerable<Training> Trainings { get; }

        TrainingViewModel GetTrainings(string UserID);

        ExerciseViewModel GetExercises(int SessionId);

        void SaveTraining(Training training);

        void SaveSession(TrainingSession session);

        void SaveExercise(Exercise exercise);

        Training DeleteTraining(int trainingID);

        TrainingSession DeleteSession(int sessionID);

        Exercise DeleteExercise(int exerciseID);
    }
}