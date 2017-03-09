using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private const string fOrC = "Celcius_or_Farenheit";
        private IWeatherDal weatherDal;

        public WeatherController(IWeatherDal weatherDal)
        {
            this.weatherDal = weatherDal;
        }
        // GET: Weather
        public ActionResult GetForecast(string code)
        {
            bool farenheit;
            if (Session[fOrC] == null)
            {
                farenheit = true;
                Session[fOrC] = farenheit;
            }
            farenheit = (bool)Session[fOrC];

            List <Weather> fiveDayForecast = weatherDal.GetFiveDayForecast(code, farenheit);
            return View("GetForecast", fiveDayForecast);
        }

    }
}