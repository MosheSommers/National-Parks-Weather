using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL.Tests
{
    [TestClass()]
    public class ParkSqlDalTests
    {
        TransactionScope tran;
        //string connectionString = ConfigurationManager.ConnectionStrings["npgeekdb"].ConnectionString;
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=npgeek;User ID=te_student;Password=sqlserver1";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Insert into park values('MOSHE', 'Moshe Grand Dam', 'Utah', 30000, 2500, 103, 47, 'Temperate', 2017, 3700, 'Your attitude is your altitude!', 'Rachel', 'A beautiful national park for rustic vacation with the family.', 20, 7)", connection);
                command.ExecuteNonQuery();

            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            tran.Dispose();
        }

        [TestMethod()]
        public void GetParkInfoTest()
        {
            ParkSqlDal dal = new ParkSqlDal(connectionString);
            Park p = dal.GetParkInfo("MOSHE");
            Assert.AreEqual("Moshe Grand Dam", p.Name);
        }

        [TestMethod()]
        public void GetParksTest()
        {
            ParkSqlDal dal = new ParkSqlDal(connectionString);
            List<Park> parks = dal.GetParks();
            Assert.IsTrue(parks.Count > 0);
        }
    }
}