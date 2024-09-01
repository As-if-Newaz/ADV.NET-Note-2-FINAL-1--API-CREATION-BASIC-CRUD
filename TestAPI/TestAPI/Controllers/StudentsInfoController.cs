using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI.EF;

namespace TestAPI.Controllers
{
    public class StudentsInfoController : ApiController
    {
        StudentsEntities db = new StudentsEntities();

        [HttpGet]
        [Route("api/students/all")]
        public HttpResponseMessage AllStudents()
        { 
            var data = db.StudentsInfoes.ToList();
            return Request.CreateResponse(HttpStatusCode.OK , data );
        
        }

        [HttpGet]
        [Route("api/students/{id}")]
        public HttpResponseMessage SingleStudents(int id)
        {
            var data = db.StudentsInfoes.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        //create operation

        [HttpPost]
        [Route("api/students/create")]
        public HttpResponseMessage CreateStudent(StudentsInfo s)
        {
            db.StudentsInfoes.Add(s);   
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Created");
        }

        [HttpPost]
        [Route("api/students/edit")]
        public HttpResponseMessage EditStudent(StudentsInfo s)
        {
            var exobj = db.StudentsInfoes.Find(s.ID);
            exobj.Name = s.Name;
            exobj.Email = s.Email;  
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Record Edited");
        }
        [HttpPost]
        [Route("api/students/delete")]
        public HttpResponseMessage DeleteStudent(StudentsInfo s)
        {
            var exobj = db.StudentsInfoes.Find(s.ID);
            db.StudentsInfoes.Remove(exobj);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");
        }
    }

}
