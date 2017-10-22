using gymNotebook.Models;
using gymNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gymNotebook.Abstract
{
    public interface ITrainingRepository
    {
        TrainingViewModel GetTrainings(string UserID);

        void SaveTraining(Training training);

        void SaveSession(TrainingSession session);

        void SaveExercise(Exercise exercise);

        Training DeleteTraining(int trainingID);

        TrainingSession DeleteSession(int sessionID);

        Exercise DeleteExercise(int exerciseID);
    }
}