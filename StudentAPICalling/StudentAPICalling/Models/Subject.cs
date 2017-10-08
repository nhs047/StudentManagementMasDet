using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace StudentAPICalling.Models
{
    public class Subject
    {
        public Subject()
        {
            this.StudentDetails = new HashSet<StudentDetail>();
        }
        [Key]
        public long SubjectID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentDetail> StudentDetails { get; set; }
    }
}