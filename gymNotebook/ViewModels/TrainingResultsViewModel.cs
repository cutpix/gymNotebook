using gymNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gymNotebook.ViewModels
{
    public class TrainingResultsViewModel
    {
        public IEnumerable<TrainingResult> TrainingResults { get; set; }
    }
}