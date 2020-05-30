using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace SchoolManagementSystem.Controllers
{
    public class TblExamMarksController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblExamMarks
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblExamMarks = db.TblExamMarks.Include(t => t.TblClass).Include(t => t.TblExam).Include(t => t.TblStudent).Include(t => t.TblUser);
            return View(tblExamMarks.ToList());
        }

        // GET: TblExamMarks/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblExamMark tblExamMark = db.TblExamMarks.Find(id);
            if (tblExamMark == null)
            {
                return HttpNotFound();
            }
            return View(tblExamMark);
        }

        // GET: TblExamMarks/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName");
            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle");
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName");
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblExamMarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamMarksId,ExamId,ClassId,StudentId,UserId,ExamMarksTotal,ExamMarksObtain")] TblExamMark tblExamMark)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblExamMark.UserId = userId;

            if (ModelState.IsValid)
            {
                db.TblExamMarks.Add(tblExamMark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName", tblExamMark.ClassId);
            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle", tblExamMark.ExamId);
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName", tblExamMark.StudentId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblExamMark.UserId);
            return View(tblExamMark);
        }

        // GET: TblExamMarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblExamMark tblExamMark = db.TblExamMarks.Find(id);
            if (tblExamMark == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName", tblExamMark.ClassId);
            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle", tblExamMark.ExamId);
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName", tblExamMark.StudentId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblExamMark.UserId);
            return View(tblExamMark);
        }

        // POST: TblExamMarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamMarksId,ExamId,ClassId,StudentId,UserId,ExamMarksTotal,ExamMarksObtain")] TblExamMark tblExamMark)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblExamMark.UserId = userId;

            if (ModelState.IsValid)
            {
                db.Entry(tblExamMark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName", tblExamMark.ClassId);
            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle", tblExamMark.ExamId);
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName", tblExamMark.StudentId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblExamMark.UserId);
            return View(tblExamMark);
        }

        // GET: TblExamMarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblExamMark tblExamMark = db.TblExamMarks.Find(id);
            if (tblExamMark == null)
            {
                return HttpNotFound();
            }
            return View(tblExamMark);
        }

        // POST: TblExamMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblExamMark tblExamMark = db.TblExamMarks.Find(id);
            db.TblExamMarks.Remove(tblExamMark);
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
