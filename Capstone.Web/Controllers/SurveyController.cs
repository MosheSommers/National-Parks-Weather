using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("SurveyForm");
        }

        [HttpPost]
        public ActionResult SurveyForm(Survey survey)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}