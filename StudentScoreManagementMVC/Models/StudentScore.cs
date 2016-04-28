using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentScoreManagementMVC.Models
{
    public class StudentScore
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public Student Student { get; set; }

        public string Course { get; set; }

        public string Score { get; set; }

    }
}