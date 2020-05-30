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
    public class TblSubmissionFeesController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblSubmissionFees
        public ActionResult Index()
        {
            var tblSubmissionFees = db.TblSubmissionFees.Include(t => t.TblClass).Include(t => t.TblProgramme).Include(t => t.TblStudent).Include(t => t.TblUser);
            return View(tblSubmissionFees.ToList());
        }

        // GET: TblSubmissionFees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSubmissionFee tblSubmissionFee = db.TblSubmissionFees.Find(id);
            if (tblSubmissionFee == null)
            {
                return HttpNotFound();
            }
            return View(tblSubmissionFee);
        }

        // GET: TblSubmissionFees/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName");
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName");
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName");
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblSubmissionFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubmissionFeeId,UserId,StudentId,ProgrammeId,ClassId,SubmissionFeeAmount,SubmissionFeeDate,SubmissionFeeMonth,SubmissionFeeDescription")] TblSubmissionFee tblSubmissionFee)
        {
            if (ModelState.IsValid)
            {
                db.TblSubmissionFees.Add(tblSubmissionFee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName", tblSubmissionFee.ClassId);
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName", tblSubmissionFee.ProgrammeId);
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName", tblSubmissionFee.StudentId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblSubmissionFee.UserId);
            return View(tblSubmissionFee);
        }

        // GET: TblSubmissionFees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSubmissionFee tblSubmissionFee = db.TblSubmissionFees.Find(id);
            if (tblSubmissionFee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName", tblSubmissionFee.ClassId);
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName", tblSubmissionFee.ProgrammeId);
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName", tblSubmissionFee.StudentId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblSubmissionFee.UserId);
            return View(tblSubmissionFee);
        }

        // POST: TblSubmissionFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubmissionFeeId,UserId,StudentId,ProgrammeId,ClassId,SubmissionFeeAmount,SubmissionFeeDate,SubmissionFeeMonth,SubmissionFeeDescription")] TblSubmissionFee tblSubmissionFee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSubmissionFee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.TblClasses, "ClassId", "ClassName", tblSubmissionFee.ClassId);
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName", tblSubmissionFee.ProgrammeId);
            ViewBag.StudentId = new SelectList(db.TblStudents, "StudentId", "StudentName", tblSubmissionFee.StudentId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblSubmissionFee.UserId);
            return View(tblSubmissionFee);
        }

        // GET: TblSubmissionFees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSubmissionFee tblSubmissionFee = db.TblSubmissionFees.Find(id);
            if (tblSubmissionFee == null)
            {
                return HttpNotFound();
            }
            return View(tblSubmissionFee);
        }

        // POST: TblSubmissionFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblSubmissionFee tblSubmissionFee = db.TblSubmissionFees.Find(id);
            db.TblSubmissionFees.Remove(tblSubmissionFee);
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
