using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StudentScoreManagementMVC.Models;

namespace StudentScoreManagementMVC.Controllers
{
    public class DefaultController : Controller
    {
        AppDbContext db=new AppDbContext();
        // GET: Default

        //        public ActionResult Index()
        //        {
        //            return View();
        //        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Student student)
        {
            if (db.Students.Any(x => x.Number == student.Number && x.Password == student.Password))
            {
                Session["UserNumber"] = student.Number;
                return RedirectToAction("Index", "StudentScores");
            }
            else
            {
                return Content("用户名或密码错误");
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Login");
        }


        public ActionResult SignOut()
        {
            Session["UserNumber"] = null;
            return RedirectToAction("Login", "Default");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}