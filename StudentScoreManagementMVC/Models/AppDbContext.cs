using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentScoreManagementMVC.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentScore> StudentScores { get; set; }

    }
}