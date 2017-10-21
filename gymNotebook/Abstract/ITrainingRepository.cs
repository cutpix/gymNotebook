using gymNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gymNotebook.Abstract
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> Trainings { get; }
    }
}