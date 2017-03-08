using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models;


namespace Capstone.Web.DAL
{
    public class ParkSqlDal : IParkDal
    {
        private const string getParksQuery = @"select parkCode, parkname, state, parkdescription from park;";
        private const string getParkDetailsQuery = "select * from park where parkcode = @code";
        private readonly string connectionString;

        public ParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Park GetParkInfo(string parkCode)
        {
            try
            {
                Park p;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(getParkDetailsQuery, connection);
                    command.Parameters.AddWithValue("@code", parkCode);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    p = CreatePark(reader);

                }
                return p;
            }
            catch (SqlException)
            {

                throw;
            }
           
        }

      

        public List<Park> GetParks()
        {
            try
            {
                List<Park> parks = new List<Park>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(getParksQuery, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Park p = new Park();

                        p.Code = Convert.ToString(reader["parkcode"]);
                        p.Name = Convert.ToString(reader["parkname"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Description = Convert.ToString(reader["parkdescription"]);

                        parks.Add(p);
                    }
                }

                return parks;

            }
            catch (SqlException)
            {

                throw;
            }

        }

        private static Park CreatePark(SqlDataReader reader)
        {
            Park p = new Park();

            p.Code = Convert.ToString(reader["parkcode"]);
            p.Name = Convert.ToString(reader["parkname"]);
            p.State = Convert.ToString(reader["state"]);
            p.Acreage = Convert.ToInt32(reader["acreage"]);
            p.Elevation = Convert.ToInt32(reader["elevationinfeet"]);
            p.MilesOfTrail = Convert.ToDouble(reader["milesoftrail"]);
            p.NumberOfCampsites = Convert.ToInt32(reader["numberofcampsites"]);
            p.Climate = Convert.ToString(reader["climate"]);
            p.YearFounded = Convert.ToInt32(reader["yearfounded"]);
            p.AnnualVisitors = Convert.ToInt32(reader["annualvisitorcount"]);
            p.Quote = Convert.ToString(reader["inspirationalquote"]);
            p.QuoteSource = Convert.ToString(reader["inspirationalquotesource"]);
            p.Description = Convert.ToString(reader["parkdescription"]);
            p.EntryFee = Convert.ToInt32(reader["entryfee"]);
            p.NumberOfSpecies = Convert.ToInt32(reader["numberofanimalspecies"]);

            return p;
        }
    }
}