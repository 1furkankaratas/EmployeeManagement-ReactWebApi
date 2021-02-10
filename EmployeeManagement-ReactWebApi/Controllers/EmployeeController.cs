using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement_ReactWebApi.Models;

namespace EmployeeManagement_ReactWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {

            DataTable table = new DataTable();

            string query = @"select Id,Name,Depertment,MailId,CONVERT(varchar(10),DOJ,120) as DOJ from dbo.Employees";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString);

            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(Employee employee)
        {

            try
            {
                DataTable table = new DataTable();

                string query = @"insert into dbo.Employees (Name,Depertment,MailId) values('" + employee.Name + @"','" + employee.Depertment + @"','" + employee.MailId + @"')";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString);

                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);

                }

                return "Added Successful";
            }
            catch (Exception e)
            {
                return "Failed to add";
            }
        }
    }
}
