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
    public class TblDesignationsController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblDesignations
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblDesignations = db.TblDesignations.Include(t => t.TblUser);
            return View(tblDesignations.ToList());
        }

        // GET: TblDesignations/Details/5
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
            TblDesignation tblDesignation = db.TblDesignations.Find(id);
            if (tblDesignation == null)
            {
                return HttpNotFound();
            }
            return View(tblDesignation);
        }

        // GET: TblDesignations/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblDesignations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesignationId,UserId,DesignationTitle,DesignationStatus")] TblDesignation tblDesignation)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblDesignation.UserId = userId;

            if (ModelState.IsValid)
            {
                db.TblDesignations.Add(tblDesignation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblDesignation.UserId);
            return View(tblDesignation);
        }

        // GET: TblDesignations/Edit/5
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
            TblDesignation tblDesignation = db.TblDesignations.Find(id);
            if (tblDesignation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblDesignation.UserId);
            return View(tblDesignation);
        }

        // POST: TblDesignations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesignationId,UserId,DesignationTitle,DesignationStatus")] TblDesignation tblDesignation)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblDesignation.UserId = userId;

            if (ModelState.IsValid)
            {
                db.Entry(tblDesignation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblDesignation.UserId);
            return View(tblDesignation);
        }

        // GET: TblDesignations/Delete/5
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
            TblDesignation tblDesignation = db.TblDesignations.Find(id);
            if (tblDesignation == null)
            {
                return HttpNotFound();
            }
            return View(tblDesignation);
        }

        // POST: TblDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblDesignation tblDesignation = db.TblDesignations.Find(id);
            db.TblDesignations.Remove(tblDesignation);
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

