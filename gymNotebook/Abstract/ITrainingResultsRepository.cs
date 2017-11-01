using gymNotebook.Models;
using gymNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gymNotebook.Abstract
{
    public interface ITrainingResultsRepository
    {
        TrainingResultsViewModel GetResults(int exerciseID, DateTime? dateStart, DateTime? dateEnd);

        void SaveResult(TrainingResult result);
    }
}