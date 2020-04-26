/*
 * @Project Bluezone
 * @Author Bluezone Global (contact@bluezone.ai)
 * @Createdate 26/04/2020, 16:36 
 *
 * This file is part of Bluezone (https://bluezone.ai)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Data;
using System.Net;
using System.Web.Http;
using System.Configuration;
using System.IO;
using MySql.Data.MySqlClient;
using System.Web;

namespace WebAPI.Controllers
{
    public class AppController : ApiController
    {
        [HttpPost]
        public string RegisterUser([FromBody]UserRegister data)
        {
            string queryString = "INSERT INTO userregister(TokenFirebase) VALUES('" + data.TokenFirebase + "')";
            string msg = ExecQueryString(queryString);
            if (msg.Length > 0) throw new HttpResponseException(HttpStatusCode.InternalServerError);
            return "Register success";
        }
        public class UserRegister
        {
            public string TokenFirebase { get; set; }
        }

        [HttpPost]
        public string ReportFound([FromBody]string jsonData)
        {
            string queryString = "INSERT INTO Report(Data) VALUES('" + jsonData + "')";
            string msg = ExecQueryString(queryString);
            if (msg.Length > 0) throw new HttpResponseException(HttpStatusCode.InternalServerError);
            return "Register success";
        }

        [HttpPost]
        public string ReportHistory([FromBody]string jsonData)
        {
            string queryString = "INSERT INTO ReportHistory(Data) VALUES('" + jsonData + "')";
            string msg = ExecQueryString(queryString);
            if (msg.Length > 0) throw new HttpResponseException(HttpStatusCode.InternalServerError);
            return "Report History success";
        }

        [HttpGet]
        public string GetConfigApp()
        {
            try
            {
                string FilePathConfigApp = ConfigurationManager.AppSettings["FilePathConfigApp"];
                string contentConfigApp = File.ReadAllText(HttpContext.Current.Server.MapPath(FilePathConfigApp));
                return contentConfigApp;
            }
            catch (Exception ex)
            {
               throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet]
        public string CheckVersion()
        {
            try
            {
                string FilePathVesionApp = ConfigurationManager.AppSettings["FilePathVesionApp"];
                string contentVesionApp = File.ReadAllText(HttpContext.Current.Server.MapPath(FilePathVesionApp));
                return contentVesionApp;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public string GetTotalUserInstallApp()
        {
            string queryString = "SELECT COUNT(ID) FROM userregister";
            string msg = ExecQueryString(queryString, out DataTable dt);            
            if (msg.Length > 0) throw new HttpResponseException(HttpStatusCode.InternalServerError);
            return dt.Rows[0][0].ToString();
        }

        string ExecQueryString(string queryString)
        {
            string msg = "";

            string MSSQL = ConfigurationManager.AppSettings["MSSQL"];
            MySqlConnection conn = new MySqlConnection(MSSQL);
            MySqlCommand scmCmdToExecute = new MySqlCommand(queryString, conn);

            scmCmdToExecute.CommandType = CommandType.Text;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msg = "SQL query error : " + ex.ToString();
            }
            finally
            {
                scmCmdToExecute?.Dispose();
                if (conn.State != ConnectionState.Closed) conn.Close();
            }

            return msg;
        }
        string ExecQueryString(string queryString, out DataTable dt)
        {
            string msg = "";
            dt = new DataTable();

            string MSSQL = ConfigurationManager.AppSettings["MSSQL"];
            MySqlConnection conn = new MySqlConnection(MSSQL);
            MySqlCommand scmCmdToExecute = new MySqlCommand(queryString, conn);

            scmCmdToExecute.CommandType = CommandType.Text;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                dt.Load(scmCmdToExecute.ExecuteReader());
            }
            catch (Exception ex)
            {
                msg = "SQL query error : " + ex.ToString();
            }
            finally
            {
                scmCmdToExecute?.Dispose();
                if (conn.State != ConnectionState.Closed) conn.Close();
            }

            return msg;
        }
    }   
}