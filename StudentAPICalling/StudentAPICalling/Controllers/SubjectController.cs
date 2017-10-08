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
    public class SubjectController : Controller
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
            HttpResponseMessage response = client.GetAsync("API/Subject").Result;
            if (response.IsSuccessStatusCode)
            {
                var variable = response.Content.ReadAsAsync<IEnumerable<Subject>>().Result;
                return View(variable);
            }
            return null;

        }
        public ActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
               
                HttpClient client = CallApi();
                HttpResponseMessage ResMsg = await this.client.PostAsJsonAsync("api/subject", subject);

                if (!ResMsg.IsSuccessStatusCode)
                {

                    return View(subject);
                }

            }

            return RedirectToAction("Index", "Subject");
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
          
                HttpClient client = CallApi();
                HttpResponseMessage response = client.GetAsync("API/Subject").Result;
                var variable = response.Content.ReadAsAsync<IEnumerable<Subject>>().Result;
                Subject subject = variable.FirstOrDefault();
                return View(subject);
             }
             return null;
         }

        [HttpPost]
        public async Task<ActionResult> Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CallApi();
                string urlLocator = "API/Subject/" + subject.SubjectID + "/";
                HttpResponseMessage ResMsg = await this.client.PutAsJsonAsync(urlLocator, subject);
                return RedirectToAction("Index");
            }
            return View(subject);

        }
	}
}