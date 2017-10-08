using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using StudentAPICalling.Models;

using System.Threading.Tasks;

namespace StudentAPICalling.Controllers
{
    public class StudentController : Controller
    {

        HttpClient client = new HttpClient();
        public HttpClient CallApi()
        {
            string baseURI = "http://localhost:14863/";
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        //
        // GET: /Student/
        public ActionResult Index()
        {
            HttpClient client = CallApi();
            HttpResponseMessage response = client.GetAsync("API/Student").Result;
            if (response.IsSuccessStatusCode)
            {
                var variable = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                return View(variable);
            }
            return null;

        }
        public ActionResult Create()
        {
            Session["GridLoad"] = null;
            HttpClient client = CallApi();
            HttpResponseMessage response = client.GetAsync("API/Subject").Result;
            ViewBag.ddlSubject = null;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.Subject = response.Content.ReadAsAsync<IEnumerable<Subject>>().Result;
               //ViewBag.ddlSubject = new SelectList(response.Content.ReadAsAsync<IEnumerable<Subject>>().Result, "SubjectID", "Name");
            }

           
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection form)
        {
            Student objStd = new Student();
            objStd.Email=form["Email"].ToString();
            objStd.Password = form["Password"].ToString();
            List<StudentDetail> stdetail = new List<StudentDetail>();
            if (ModelState.IsValid)
            {
                foreach(var i in form)
                {
                    try
                    {
                        StudentDetail stdtl = new StudentDetail();
                        int subId = Convert.ToInt16(i);
                        stdtl.SubjectID = subId;
                        decimal marks = 0;
                        try
                        {
                            marks = Convert.ToDecimal(form["" + i + ""].ToString());
                        }
                        catch (Exception ex)
                        {

                        }
                        stdtl.Mark = marks;
                        objStd.StudentDetails.Add(stdtl);
                    }
                    catch(Exception ex)
                    {

                    }
                }
                HttpClient client = CallApi();
                HttpResponseMessage ResMsg = await this.client.PostAsJsonAsync("api/student", objStd);

                if (!ResMsg.IsSuccessStatusCode)
                {

                    return View();
                }
           
            }

            return RedirectToAction("Index", "Student");
        }
        //http GET/1
        public ActionResult Details(long ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                HttpClient client = CallApi();
                string urlPost = "API/Student/" + id + "/";
                HttpResponseMessage response = client.GetAsync(urlPost).Result;
                if (response.IsSuccessStatusCode)
                {
                    var variable = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                    Student students = variable.FirstOrDefault();
                    return View(students);
                }
                return null;
            }
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Session["GridLoad"] = null;
                HttpClient client = CallApi();
                string urlPost = "API/Student/" + id + "/";
                HttpResponseMessage response = client.GetAsync(urlPost).Result;
                if (response.IsSuccessStatusCode)
                {
                    var variable = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                    Student students = variable.FirstOrDefault();
                    return View(students);
                }
                return null;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(FormCollection form)
        {
            Student student = new Student();
            long stID=Convert.ToInt64(form["StudentID"].ToString());
            student.StudentID = stID;
            student.Email = form["Email"].ToString();
            student.Password = form["Password"].ToString();
            if (ModelState.IsValid)
            {
                foreach(var i in form)
                {
                    try
                    {
                        StudentDetail stdtl = new StudentDetail();
                        int subId = Convert.ToInt16(i);
                        stdtl.SubjectID = subId;
                        decimal marks = 0;
                        try
                        {
                            marks = Convert.ToDecimal(form["" + i + ""].ToString());
                        }
                        catch (Exception ex)
                        {

                        }
                        stdtl.Mark = marks;
                        student.StudentDetails.Add(stdtl);
                    }
                    catch(Exception ex)
                    {

                    }
                }
                HttpClient client = CallApi();
                string urlLocator = "API/Student/" + student.StudentID + "/";
                HttpResponseMessage ResMsg = await this.client.PutAsJsonAsync(urlLocator, student);
                return RedirectToAction("Index");



                //HttpClient client = CallApi();
                //HttpResponseMessage ResMsg = await this.client.PostAsJsonAsync("api/student", objStd);

                //if (!ResMsg.IsSuccessStatusCode)
                //{

                //    return View();
                //}
           
            }
                

               
            
            return View(student);

        }
      
        public ActionResult Delete(long id)
        {
            HttpClient client = CallApi();
            HttpResponseMessage response = client.DeleteAsync("API/Student/" + id).Result;
            return RedirectToAction("Index");
        }
        public class returnStudent
        {
            internal string Email { get; set; }
            internal string Password { get; set; }
        }
    }
    public class StudentMarks
    {
        public string SubId { get; set; }
        public string Sub { get; set; }
        public string Marks { get; set; }
    }
}