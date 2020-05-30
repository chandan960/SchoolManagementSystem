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
    public class TblProgrammesController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblProgrammes
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblProgrammes = db.TblProgrammes.Include(t => t.TblUser);
            return View(tblProgrammes.ToList());
        }

        // GET: TblProgrammes/Details/5
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
            TblProgramme tblProgramme = db.TblProgrammes.Find(id);
            if (tblProgramme == null)
            {
                return HttpNotFound();
            }
            return View(tblProgramme);
        }

        // GET: TblProgrammes/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblProgrammes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgrammeId,UserId,ProgrammeName,ProgrammeStartDate,ProgrammeStatus")] TblProgramme tblProgramme)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblProgramme.UserId = userId;

            if (ModelState.IsValid)
            {
                db.TblProgrammes.Add(tblProgramme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblProgramme.UserId);
            return View(tblProgramme);
        }

        // GET: TblProgrammes/Edit/5
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
            TblProgramme tblProgramme = db.TblProgrammes.Find(id);
            if (tblProgramme == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblProgramme.UserId);
            return View(tblProgramme);
        }

        // POST: TblProgrammes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgrammeId,UserId,ProgrammeName,ProgrammeStartDate,ProgrammeStatus")] TblProgramme tblProgramme)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblProgramme.UserId = userId;

            if (ModelState.IsValid)
            {
                db.Entry(tblProgramme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblProgramme.UserId);
            return View(tblProgramme);
        }

        // GET: TblProgrammes/Delete/5
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
            TblProgramme tblProgramme = db.TblProgrammes.Find(id);
            if (tblProgramme == null)
            {
                return HttpNotFound();
            }
            return View(tblProgramme);
        }

        // POST: TblProgrammes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblProgramme tblProgramme = db.TblProgrammes.Find(id);
            db.TblProgrammes.Remove(tblProgramme);
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
