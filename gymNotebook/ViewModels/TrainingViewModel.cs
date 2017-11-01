using gymNotebook.Models;
using System;
using System.Collections.Generic;

namespace gymNotebook.ViewModels
{
    public class TrainingViewModel
    {
        public IEnumerable<Training> Trainings { get; set; }
        public IEnumerable<TrainingSession> TrainingSessions { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
    }

    public class ExerciseViewModel
    {
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}