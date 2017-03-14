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
        private IParkDal parkDal;
        public SurveyController(ISurveyDal surveyDal, IParkDal parkDal)
        {
            this.surveyDal = surveyDal;
            this.parkDal = parkDal;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Park> parks = parkDal.GetParks();
            Survey model = new Survey();
            foreach (Park p in parks)
            {
                model.Parks.Add(new SelectListItem() { Text = p.Name, Value = p.Code });
            } 

            return View("Survey",model);
        }

        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            surveyDal.CreateSurvey(survey);
            return RedirectToAction("Index", "Home");
        }
    }
}