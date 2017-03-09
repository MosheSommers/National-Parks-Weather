using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDal : IWeatherDal
    {

        private const string fiveDayWeatherQuery = @"Select * from weather where parkCode = @code order by fiveDayForecastValue asc";

        private string connectionString;
        public WeatherSqlDal(string connectionString)
        {

            this.connectionString = connectionString;
        }

        public List<Weather> GetFiveDayForecast(string code, bool farenheit)
        {
            try
            {
                List<Weather> fiveDayForecast = new List<Weather>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(fiveDayWeatherQuery, connection);
                    command.Parameters.AddWithValue("@code", code);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                       Weather w = new Weather(farenheit);

                        w.ParkCode = Convert.ToString(reader["parkcode"]);
                        w.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.LowTemp = Convert.ToInt32(reader["low"]);
                        w.HighTemp = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);

                        fiveDayForecast.Add(w);
                    }
                }

                return fiveDayForecast;
            }
            catch
            {
                throw;
            }
        }
    }
}