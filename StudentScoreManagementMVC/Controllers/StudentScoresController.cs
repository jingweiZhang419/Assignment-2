using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentScoreManagementMVC.Models;

namespace StudentScoreManagementMVC.Controllers
{
    public class StudentScoresController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: StudentScores
        public ActionResult Index()
        {
            var studentScores = db.StudentScores.Include(s => s.Student);

            var ss = new List<StudentScore>();

            if (Session["UserNumber"] != null)
            {
                var number = (string) Session["UserNumber"];
                if (number == "admin")
                {
                    ss = studentScores.ToList();
                }
                else
                {
                    ss = studentScores.Where(x => x.Student.Number == number).ToList();
                }
                
            }

            return View(ss);
        }
     
     

        // GET: StudentScores/Create
        public ActionResult Create()
        {
            var list = new List<SelectListItem>();

            SelectListItem item = new SelectListItem();
            item.Text = "information system";
            item.Value = "information system";
            list.Add(item);

            item = new SelectListItem();
            item.Text = "computer science";
            item.Value = "computer science";
            list.Add(item);

            item = new SelectListItem();
            item.Text = "computer game design";
            item.Value = "computer game design";
            list.Add(item);

            item = new SelectListItem();
            item.Text = "computer system security";
            item.Value = "computer system security";
            list.Add(item);

            ViewBag.Course = list;

            ViewBag.StudentId = new SelectList(db.Students.Where(x => x.Number != "admin"), "Id", "Name");
            return View();
        }

        // POST: StudentScores/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,Course,Score")] StudentScore studentScore)
        {
            if (ModelState.IsValid)
            {
                db.StudentScores.Add(studentScore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentScore.StudentId);
            return View(studentScore);
        }

        // GET: StudentScores/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentScore studentScore = db.StudentScores.Find(id);
            if (studentScore == null)
            {
                return HttpNotFound();
            }
            var list = new List<SelectListItem>();

            SelectListItem item = new SelectListItem();
            item.Text = "information system";
            item.Value = "information system";
            list.Add(item);

            item = new SelectListItem();
            item.Text = "computer science";
            item.Value = "computer science";
            list.Add(item);

            item = new SelectListItem();
            item.Text = "computer game design";
            item.Value = "computer game design";
            list.Add(item);

            item = new SelectListItem();
            item.Text = "computer system security";
            item.Value = "computer system security";
            list.Add(item);

            ViewBag.Course = list;
            ViewBag.StudentId = new SelectList(db.Students.Where(x=>x.Number!="admin"), "Id", "Name", studentScore.StudentId);
            return View(studentScore);
        }

        // POST: StudentScores/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,Course,Score")] StudentScore studentScore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentScore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentScore.StudentId);
            return View(studentScore);
        }

        // GET: StudentScores/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentScore studentScore = db.StudentScores.Find(id);
            if (studentScore == null)
            {
                return HttpNotFound();
            }
            return View(studentScore);
        }

        // POST: StudentScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            StudentScore studentScore = db.StudentScores.Find(id);
            db.StudentScores.Remove(studentScore);
            db.SaveChanges();
            return RedirectToAction("Index");
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
