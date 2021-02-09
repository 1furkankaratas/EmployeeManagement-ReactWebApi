using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement_ReactWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Depertment { get; set; }
        public string MailId { get; set; }
        public DateTime? DOJ { get; set; }
    }
}