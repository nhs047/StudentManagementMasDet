using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace StudentAPICalling.Models
{
    public class StudentDetail
    {
        public StudentDetail()
        {
           
        }
        public long ID { get; set; }
        public Nullable<long> StudentID { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public Nullable<decimal> Mark { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }




        

 

  
    }
}