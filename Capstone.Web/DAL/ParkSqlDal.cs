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


        private readonly string connectionString;

        public ParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Park> GetParkInfo(string parkCode)
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

        public List<Park> GetParks()
        {
            throw new NotImplementedException();
        }
    }
}