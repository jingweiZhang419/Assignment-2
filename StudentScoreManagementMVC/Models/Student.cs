using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentScoreManagementMVC.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }

    }
}