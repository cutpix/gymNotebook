using gymNotebook.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gymNotebook.Models;

namespace gymNotebook.Concrete
{
    public class EFTrainingRepository : ITrainingRepository
    {
        private TrainingContext context = new TrainingContext();

        public IEnumerable<Training> Trainings
        {
            get { return context.Trainings; }
        }
    }
}