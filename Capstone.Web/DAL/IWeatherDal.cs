﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IWeatherDal
    {
        List<Weather> GetFiveDayForecast(string code, bool farenheit);
       
    }
}
