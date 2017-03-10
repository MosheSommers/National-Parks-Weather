using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDal surveyDal;
        public SurveyController(ISurveyDal surveyDal)
        {
            this.surveyDal = surveyDal;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View("Survey");
        }

        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            surveyDal.CreateSurvey(survey);
            return RedirectToAction("Index", "Home");
        }
    }
}