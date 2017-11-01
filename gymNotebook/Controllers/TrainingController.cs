using gymNotebook.Abstract;
using gymNotebook.App_Start;
using gymNotebook.Concrete;
using gymNotebook.Models;
using gymNotebook.ViewModels;
using gymNotebook.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace gymNotebook.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        private ITrainingManageRepository repository;
        public TrainingController(ITrainingManageRepository trainingRepository)
        {
            this.repository = trainingRepository;
        }

        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            TrainingViewModel training = repository.GetTrainings(user.Id);

            return View(training);
        }

        [HttpPost]
        public ActionResult DeleteTrainig(int trainingId)
        {
            Training deletedTraining = repository.DeleteTraining(trainingId);
            if (deletedTraining != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedTraining.TrainingName);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> StartTraining()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            TrainingViewModel training = repository.GetTrainings(user.Id);

            return View(training);
        }


    }
}