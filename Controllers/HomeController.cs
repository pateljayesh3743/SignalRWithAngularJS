using Microsoft.AspNet.SignalR;
using SignalRWithAngularJS.Hubs;
using SignalRWithAngularJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRWithAngularJS.Controllers
{
    public class HomeController : Controller
    {
        studentEntities1 db = new studentEntities1();
        public ActionResult Index()
        {    
            return View();
        }

        public JsonResult GetStudent()
        {
            return Json(db.studentfirstclasses.ToList(),JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddStudent(StudentModel model)
        {
            studentfirstclass objTable = new studentfirstclass();
            objTable.name = model.student_name;
            db.studentfirstclasses.Add(objTable);
            db.SaveChanges();
            MyHub.BroadcastData(objTable);    
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}