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
    public class ItalianPhrasesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                select PhraseId, Phrase, Translation0, Translation1, Translation2, 
                Translation3, Translation4, Translation5, Translation6, Translation7, 
                Translation8, Translation9, PhraseAudioFileName, TranslationAudioFileName 
                from dbo.ItalianPhrases
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


        public string Post(ItalianPhrases phrase)
        {
            try
            {
                string query = @"
                    insert into dbo.ItalianPhrases values
                    ('" + phrase.Phrase + @"'
                    ,'" + phrase.Translation0 + @"'
                    ,'" + phrase.Translation1 + @"'
                    ,'" + phrase.Translation2 + @"'
                    ,'" + phrase.Translation3 + @"'
                    ,'" + phrase.Translation4 + @"'
                    ,'" + phrase.Translation5 + @"'
                    ,'" + phrase.Translation6 + @"'
                    ,'" + phrase.Translation7 + @"'
                    ,'" + phrase.Translation8 + @"'
                    ,'" + phrase.Translation9 + @"'
                    ,'" + phrase.PhraseAudioFileName + @"'
                    ,'" + phrase.TranslationAudioFileName + @"'
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

        public string Put(ItalianPhrases phrase)
        {
            try
            {
                string query = @"
                    update dbo.ItalianPhrases set 
                    Phrase='" + phrase.Phrase + @"'
                    ,Translation0='" + phrase.Translation0 + @"'
                    ,Translation1='" + phrase.Translation1 + @"'
                    ,Translation2='" + phrase.Translation2 + @"'
                    ,Translation3='" + phrase.Translation3 + @"'
                    ,Translation4='" + phrase.Translation4 + @"'
                    ,Translation5='" + phrase.Translation5 + @"'
                    ,Translation6='" + phrase.Translation6 + @"'
                    ,Translation7='" + phrase.Translation7 + @"'
                    ,Translation8='" + phrase.Translation8 + @"'
                    ,Translation9='" + phrase.Translation9 + @"'
                    ,PhraseAudioFileName='" + phrase.PhraseAudioFileName + @"'
                    ,TranslationAudioFileName='" + phrase.TranslationAudioFileName + @"'
                    where PhraseId=" + phrase.PhraseId + @"
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
                    delete from dbo.ItalianPhrases
                    where PhraseId=" + id + @"
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