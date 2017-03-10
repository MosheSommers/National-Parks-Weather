using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDal : ISurveyDal
    {
        private string connectionString;
        public SurveySqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void CreateSurvey(Survey survey)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Insert into survey_result values(@parkCode, @emailAddress, @state, @activityLevel)", connection);
                    command.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    command.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    command.Parameters.AddWithValue("@state", survey.State);
                    command.Parameters.AddWithValue("@activityLevel", survey.Activity);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }

        public List<Survey> GetSurveys()
        {
            throw new NotImplementedException();
        }
    }
}