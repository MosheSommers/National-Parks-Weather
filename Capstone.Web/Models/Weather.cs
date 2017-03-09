using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public Weather()
        {
            Farenheit = true;
        }

        public string ParkCode { get; set; }
        public int Day { get; set; }
        public int LowTemp { get; set; }
        public int HighTemp { get; set; }
        public string Forecast { get; set; }
        public string Suggestion { get; set; }
        public bool Farenheit { get; set;  }

        public string GetSuggestion ()
        {
            Suggestion = "";

            switch (Forecast)
            {
                case "snow":
                    Suggestion = "Pack snowshoes.";
                    break;

                case "rain":
                    Suggestion = "Pack raingear and wear waterproof shoes.";
                    break;

                case "thunderstorms":
                    Suggestion = "Seek shelter and avoid hiking on exposed ridges.";
                    break;

                case "sunny":
                    Suggestion = "Be sure to pack sunblock.";
                    break;

                default:
                    break;
            }

            if (HighTemp > 75)
            {
                Suggestion += " Bring an extra gallon of water.";
            }

            if (LowTemp < 20)
            {
                Suggestion += " Please be aware of the dangers of exposure to frigid temperatures.";
            }

            if ((HighTemp - LowTemp) > 20)
            {
                Suggestion += " Wear breathable layers.";
            }

            return Suggestion;
        }
    }
}