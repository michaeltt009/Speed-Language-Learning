using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EnglishPhrasesTimesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                select StudiedPhraseId, PhraseId, AmountStudied, LastStudiedTime, AverageStudiedTime 
                from dbo.EnglishPhrasesTimes
                ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["LanguageLearningAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        
        public string Post(EnglishPhrasesTimes phrase)
        {
            try
            {
                string query = @"
                    insert into dbo.EnglishPhrasesTimes values
                    ('" + phrase.PhraseId + @"'
                    ,'" + phrase.AmountStudied + @"'
                    ,'" + phrase.LastStudiedTime + @"'
                    ,'" + phrase.AverageStudiedTime + @"'
                    )";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["LanguageLearningAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Add!";
            }
        }

        public string Put(EnglishPhrasesTimes phrase)
        {
            try
            {
                string query = @"
                    update dbo.EnglishPhrasesTimes set 
                    PhraseId='" + phrase.PhraseId + @"'
                    ,AmountStudied='" + phrase.AmountStudied + @"'
                    ,PhraseAudioFileName='" + phrase.LastStudiedTime + @"'
                    ,TranslationAudioFileName='" + phrase.AverageStudiedTime + @"'
                    where StudiedPhraseId=" + phrase.StudiedPhraseId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["LanguageLearningAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Update!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.EnglishPhrasesTimes
                    where StudiedPhraseId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["LanguageLearningAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }
    }
}
