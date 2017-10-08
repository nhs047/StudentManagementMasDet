using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    public class StudentController : ApiController
    {
        private SMSEntities db = new SMSEntities();

        // GET api/Student
        public dynamic GetStudents()
        {
          var a= db.Students.Select(p => new
            {
                p.Email,
                p.StudentID,
                p.Password,
                StudentDetails = db.StudentDetails.Where(o => o.StudentID == p.StudentID).Select(q => new { q.SubjectID, q.Mark,Subject=q.Subject}).ToList()
            }).ToList();
          return a;
        }

        // GET api/Student/5
        [ResponseType(typeof(Student))]
        public dynamic GetStudent(long id)
        {
            var student = db.Students.Where(h=>h.StudentID==id).Select(p => new
            {
                p.Email,
                p.StudentID,
                p.Password,
                StudentDetails = db.StudentDetails.Where(o => o.StudentID == p.StudentID).Select(q => new { q.SubjectID, q.Mark, Subject = q.Subject }).ToList()
            }).ToList();
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT api/Student/5
        public IHttpActionResult PutStudent(long id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentID)
            {

                return BadRequest();
            }

            foreach (var std in student.StudentDetails)
            {
                
                try
                {
                   var stdd = db.StudentDetails.Where(d => d.StudentID == id && d.SubjectID == std.SubjectID).First();
                  
                   
                       stdd.Mark = std.Mark;
                       db.Entry(stdd).State = EntityState.Modified;
                       db.SaveChanges();
                   
                }
                catch (Exception ex)
                {
                    std.StudentID = id;
                    db.StudentDetails.Add(std);
                    db.SaveChanges();
                }
              
               
            }
            var stDetailDB = db.StudentDetails.Where(d => d.StudentID == student.StudentID).ToList();
            foreach (var det in stDetailDB)
            {
                if (student.StudentDetails.Any(st => st.SubjectID == det.SubjectID))
                {

                }
                else
                {
                    db.StudentDetails.Remove(det);
                    db.SaveChanges();
                }
            }
            var studentMaster = db.Students.Where(d => d.StudentID == id).First();
            studentMaster.Email = student.Email;
            studentMaster.Password = student.Password;
            db.Entry(studentMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Student
        [ResponseType(typeof(Student))]
        public string PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return "fail";
            }

            db.Students.Add(student);
            db.SaveChanges();

            return "success";
        }

        // DELETE api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(long id)
        {
            Student student = db.Students.Find(id);
            

            if (student == null)
            {
                return NotFound();
            }
            try
            {
                var stDetail = db.StudentDetails.Where(d => d.StudentID == id);
                foreach (var detail in stDetail)
                {
                    db.StudentDetails.Remove(detail);
                   
                }
            }
            catch (Exception ex)
            {

            }
            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(long id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}