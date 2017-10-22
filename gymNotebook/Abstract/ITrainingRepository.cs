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
    }
}