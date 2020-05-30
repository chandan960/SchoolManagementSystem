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
    public class TblSubjectsController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblSubjects
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblSubjects = db.TblSubjects.Include(t => t.TblUser);
            return View(tblSubjects.ToList());
        }

        // GET: TblSubjects/Details/5
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
            TblSubject tblSubject = db.TblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // GET: TblSubjects/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,UserId,SubjectName,SubjectRegistrationDate,SubjectDescription")] TblSubject tblSubject)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblSubject.UserId = userId;

            if (ModelState.IsValid)
            {
                db.TblSubjects.Add(tblSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblSubject.UserId);
            return View(tblSubject);
        }

        // GET: TblSubjects/Edit/5
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
            TblSubject tblSubject = db.TblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblSubject.UserId);
            return View(tblSubject);
        }

        // POST: TblSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,UserId,SubjectName,SubjectRegistrationDate,SubjectDescription")] TblSubject tblSubject)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblSubject.UserId = userId;

            if (ModelState.IsValid)
            {
                db.Entry(tblSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblSubject.UserId);
            return View(tblSubject);
        }

        // GET: TblSubjects/Delete/5
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
            TblSubject tblSubject = db.TblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // POST: TblSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblSubject tblSubject = db.TblSubjects.Find(id);
            db.TblSubjects.Remove(tblSubject);
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

