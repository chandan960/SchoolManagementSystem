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
    public class TblClassSubjectsController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblClassSubjects
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblClassSubjects = db.TblClassSubjects.Include(t => t.TblClass).Include(t => t.TblSubject);
            return View(tblClassSubjects.ToList());
        }

        // GET: TblClassSubjects/Details/5
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
            TblClassSubject tblClassSubject = db.TblClassSubjects.Find(id);
            if (tblClassSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblClassSubject);
        }

        // GET: TblClassSubjects/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.ClassId = new SelectList(db.TblClasses.Where(t => t.ClassStatus == true), "ClassId", "ClassName");
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: TblClassSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassSubjectId,ClassId,SubjectId,ClassSubjectTitle,ClassSubjectStatus")] TblClassSubject tblClassSubject)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }



            if (ModelState.IsValid)
            {
                db.TblClassSubjects.Add(tblClassSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.TblClasses.Where(t => t.ClassStatus == true), "ClassId", "ClassName", tblClassSubject.ClassId);
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName", tblClassSubject.SubjectId);
            return View(tblClassSubject);
        }

        // GET: TblClassSubjects/Edit/5
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
            TblClassSubject tblClassSubject = db.TblClassSubjects.Find(id);
            if (tblClassSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.TblClasses.Where(t => t.ClassStatus == true), "ClassId", "ClassName", tblClassSubject.ClassId);
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName", tblClassSubject.SubjectId);
            return View(tblClassSubject);
        }

        // POST: TblClassSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassSubjectId,ClassId,SubjectId,ClassSubjectTitle,ClassSubjectStatus")] TblClassSubject tblClassSubject)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                db.Entry(tblClassSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.TblClasses.Where(t => t.ClassStatus == true), "ClassId", "ClassName", tblClassSubject.ClassId);
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName", tblClassSubject.SubjectId);
            return View(tblClassSubject);
        }

        // GET: TblClassSubjects/Delete/5
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
            TblClassSubject tblClassSubject = db.TblClassSubjects.Find(id);
            if (tblClassSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblClassSubject);
        }

        // POST: TblClassSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblClassSubject tblClassSubject = db.TblClassSubjects.Find(id);
            db.TblClassSubjects.Remove(tblClassSubject);
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
