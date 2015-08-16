using System;
using Microsoft.AspNet.Mvc;
using System.Data.SqlClient;
using Newtonsoft.Json;
using AspireAppsWebApiViews.Models;

namespace AspireAppsWebApiViews.Controllers
{
    [Route("api/[controller]", Name ="AdacityAPIRoute")]
    public class AdacitySurveyController : Controller
    {
        public AdacitySurveyController() { }
        public string ConnectionString
        {
            get
            {
                return @"Data Source=bgleussnf6.database.windows.net;Initial Catalog=AspireApps;Integrated Security=False;User ID=aspireapps;Password=Chaitu@3;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
        }

        [HttpPost]
        [Route("AddSurvey", Name ="AdacityAddSurveyAPIRoute")]
        public bool AddSurvey(AdacitySurvey surveyData)
        {
            var result = false;
            if (surveyData != null)
            {
                result = AddSurveyToDB(surveyData);
            }

            return result;
        }

        [HttpPost]
        [Route("AddSurveyFromJson", Name = "AdacityAddSurveyFromJsonAPIRoute")]
        public bool AddSurveyFromJson(string jsonString)
        {
            AdacitySurvey surveyData = JsonConvert.DeserializeObject<AdacitySurvey>(jsonString);
            return AddSurveyToDB(surveyData);
        }

        #region Helpermethods
        [NonAction]
        private bool AddSurveyToDB(AdacitySurvey surveyData)
        {
            var result = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[adacitySurvey].[SaveSurvey]";
                cmd.Parameters.AddWithValue("@AgeGroup", surveyData.AgeGroup);
                cmd.Parameters.AddWithValue("@Employment", surveyData.Employment);
                cmd.Parameters.AddWithValue("@Option", surveyData.Option);
                cmd.Parameters.AddWithValue("@EmploymentCategory", surveyData.EmploymentCategory);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = false;
                    throw;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }

                return result;
            }
        }
        #endregion
    }
}