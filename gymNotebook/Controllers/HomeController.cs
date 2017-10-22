using gymNotebook.Abstract;
using gymNotebook.App_Start;
using gymNotebook.Concrete;
using gymNotebook.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gymNotebook.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        private ITrainingRepository repository;

        public HomeController(ITrainingRepository trainingRepository)
        {
            this.repository = trainingRepository;
        }

        public ActionResult Index()
        {
            // var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            // var trainings = repository.Trainings.Where(t => t.UserId == user.Id);

            return View();
        }
      
        
    }
}