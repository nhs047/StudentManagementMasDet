using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPICalling.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentDetails = new HashSet<StudentDetail>();
        }

        public long StudentID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<StudentDetail> StudentDetails { get; set; }
    }
}