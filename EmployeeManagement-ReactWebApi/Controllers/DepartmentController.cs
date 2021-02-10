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
    public class DepartmentController : ApiController
    {

        public HttpResponseMessage Get()
        {

            DataTable table = new DataTable();

            string query = @"select Id,Name from dbo.Depertments";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString);

            var command = new SqlCommand(query,con);

            using (var da=new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }
        
        public string Post(Department department)
        {

            try
            {
                DataTable table = new DataTable();

                string query = @"insert into dbo.Depertments values('"+department.Name+@"')";

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
        
        
        public string Put(Department department)
        {

            try
            {
                DataTable table = new DataTable();

                string query = @"update dbo.Depertments set Name='"+department.Name+@"'where Id="+department.Id+@"";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString);

                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);

                }

                return "Update Successful";
            }
            catch (Exception e)
            {
                return "Failed to update";
            }
        }
        
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"Delete from dbo.Depertments where Id="+id;

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString);

                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Delete Successful";
            }
            catch (Exception e)
            {
                return "Failed to delete";
            }
        }
    }
}
