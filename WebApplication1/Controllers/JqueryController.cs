using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class JqueryController : Controller
    {
        // GET: Jquery
        public ActionResult Jquery()
        {
            return View();
        }

        public JsonResult GetData()
        {
            Student newStudent = new Student();
            newStudent.name = "Aaron";

            return this.Json(newStudent, JsonRequestBehavior.AllowGet);
        }

        public ContentResult GetData2()
        {
            ContentResult content = new ContentResult();
            content.Content = "{\"name\":\"aaron\"}";
            content.ContentType = "application/json";

            return content;
        }
    }
}