using System;
using Microsoft.AspNet.Mvc;
using System.Data.SqlClient;
using Newtonsoft.Json;
using AspireAppsWebApiViews.Models;
using System.Collections.Generic;
using System.Data;

namespace AspireAppsWebApiViews.Controllers
{
    [Route("api/[controller]", Name = "AdacityAPIRoute")]
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
        [Route("AddSurvey", Name = "AdacityAddSurveyAPIRoute")]
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

        [HttpGet]
        public IEnumerable<AdacitySurvey> GetSurveys()
        {
            IList<AdacitySurvey> surveyResult = new List<AdacitySurvey>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                DataSet surveys = new DataSet();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[adacitySurvey].[GetSurveys]";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                try
                {
                    conn.Open();
                    var res = adapter.Fill(surveys);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }

                var surveysCollection = surveys.Tables[0];
                foreach (DataRow survey in surveysCollection.Rows)
                {
                    surveyResult.Add(new AdacitySurvey {
                        ID = Convert.ToInt32(Convert.ToString(survey["ID"])),
                        AgeGroup = Convert.ToString(survey["age_group"]),
                        Employment = Convert.ToString(survey["employment"]),
                        EntertainmentCategory = Convert.ToString(survey["entertainment_category"]),
                        Option = Convert.ToString(survey["opinion"])
                    });
                }
            }
            return surveyResult;
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
                cmd.Parameters.AddWithValue("@EntertainmentCategory", surveyData.EntertainmentCategory);

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