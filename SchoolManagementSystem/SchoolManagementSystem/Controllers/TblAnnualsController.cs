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
    public class TblAnnualsController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblAnnuals
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblAnnuals = db.TblAnnuals.Include(t => t.TblProgramme).Include(t => t.TblUser).Where(t => t.TblProgramme.ProgrammeStatus == true);
            return View(tblAnnuals.ToList());
        }

        // GET: TblAnnuals/Details/5
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
            TblAnnual tblAnnual = db.TblAnnuals.Find(id);
            if (tblAnnual == null)
            {
                return HttpNotFound();
            }
            return View(tblAnnual);
        }

        // GET: TblAnnuals/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes.Where(t => t.ProgrammeStatus == true), "ProgrammeId", "ProgrammeName");
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblAnnuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnnualId,UserId,ProgrammeId,AnnualTitle,AnnualDescription,AnnualFees,AnnualStatus")] TblAnnual tblAnnual)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblAnnual.UserId = userId;

            if (ModelState.IsValid)
            {
                db.TblAnnuals.Add(tblAnnual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes.Where(t => t.ProgrammeStatus == true), "ProgrammeId", "ProgrammeName", tblAnnual.ProgrammeId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblAnnual.UserId);
            return View(tblAnnual);
        }

        // GET: TblAnnuals/Edit/5
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
            TblAnnual tblAnnual = db.TblAnnuals.Find(id);
            if (tblAnnual == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes.Where(t => t.ProgrammeStatus == true), "ProgrammeId", "ProgrammeName", tblAnnual.ProgrammeId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblAnnual.UserId);
            return View(tblAnnual);
        }

        // POST: TblAnnuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnnualId,UserId,ProgrammeId,AnnualTitle,AnnualDescription,AnnualFees,AnnualStatus")] TblAnnual tblAnnual)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblAnnual.UserId = userId;

            if (ModelState.IsValid)
            {
                db.Entry(tblAnnual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes.Where(t => t.ProgrammeStatus == true), "ProgrammeId", "ProgrammeName", tblAnnual.ProgrammeId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblAnnual.UserId);
            return View(tblAnnual);
        }

        // GET: TblAnnuals/Delete/5
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
            TblAnnual tblAnnual = db.TblAnnuals.Find(id);
            if (tblAnnual == null)
            {
                return HttpNotFound();
            }
            return View(tblAnnual);
        }

        // POST: TblAnnuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblAnnual tblAnnual = db.TblAnnuals.Find(id);
            db.TblAnnuals.Remove(tblAnnual);
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

