using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
namespace StudentAPICalling.Models
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetail> StudentDetails{ get; set; }
    }
}