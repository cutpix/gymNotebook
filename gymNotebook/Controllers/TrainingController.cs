﻿using gymNotebook.App_Start;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gymNotebook.Controllers
{
    public class TrainingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}