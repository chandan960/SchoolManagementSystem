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
    public class TblProgrammeSessionsController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblProgrammeSessions
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblProgrammeSessions = db.TblProgrammeSessions.Include(t => t.TblProgramme).Include(t => t.TblSession).Include(t => t.TblUser);
            return View(tblProgrammeSessions.ToList());
        }

        // GET: TblProgrammeSessions/Details/5
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
            TblProgrammeSession tblProgrammeSession = db.TblProgrammeSessions.Find(id);
            if (tblProgrammeSession == null)
            {
                return HttpNotFound();
            }
            return View(tblProgrammeSession);
        }

        // GET: TblProgrammeSessions/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName");
            ViewBag.SessionId = new SelectList(db.TblSessions, "SessionId", "SessionName");
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblProgrammeSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgrammeSessionId,UserId,ProgrammeId,SessionId,ProgrammeSessionDetails,ProgrammeSessionRegistrationDate,ProgrammeSessionDescription")] TblProgrammeSession tblProgrammeSession)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblProgrammeSession.UserId = userId;

            var sessionName = db.TblSessions.Where(t => t.SessionId == tblProgrammeSession.SessionId).SingleOrDefault();
            var programmeName = db.TblProgrammes.Where(t => t.ProgrammeId == tblProgrammeSession.ProgrammeId).SingleOrDefault();
            if (sessionName != null)
            {
                if (!tblProgrammeSession.ProgrammeSessionDetails.Contains(sessionName.SessionName))
                {
                    var details = "(" + sessionName.SessionName + "-" + (programmeName != null ? programmeName.ProgrammeName : "") + ")" + tblProgrammeSession.ProgrammeSessionDetails;
                    tblProgrammeSession.ProgrammeSessionDetails = details;
                }
            }

            if (ModelState.IsValid)
            {
                db.TblProgrammeSessions.Add(tblProgrammeSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName", tblProgrammeSession.ProgrammeId);
            ViewBag.SessionId = new SelectList(db.TblSessions, "SessionId", "SessionName", tblProgrammeSession.SessionId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblProgrammeSession.UserId);
            return View(tblProgrammeSession);
        }

        // GET: TblProgrammeSessions/Edit/5
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
            TblProgrammeSession tblProgrammeSession = db.TblProgrammeSessions.Find(id);
            if (tblProgrammeSession == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName", tblProgrammeSession.ProgrammeId);
            ViewBag.SessionId = new SelectList(db.TblSessions, "SessionId", "SessionName", tblProgrammeSession.SessionId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblProgrammeSession.UserId);
            return View(tblProgrammeSession);
        }

        // POST: TblProgrammeSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgrammeSessionId,UserId,ProgrammeId,SessionId,ProgrammeSessionDetails,ProgrammeSessionRegistrationDate,ProgrammeSessionDescription")] TblProgrammeSession tblProgrammeSession)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblProgrammeSession.UserId = userId;

            var sessionName = db.TblSessions.Where(t => t.SessionId == tblProgrammeSession.SessionId).SingleOrDefault();
            var programmeName = db.TblProgrammes.Where(t => t.ProgrammeId == tblProgrammeSession.ProgrammeId).SingleOrDefault();
            if (sessionName != null || programmeName != null)
            {
                if (!tblProgrammeSession.ProgrammeSessionDetails.Contains(sessionName.SessionName) || !tblProgrammeSession.ProgrammeSessionDetails.Contains(programmeName.ProgrammeName))
                {
                    var details = "(" + sessionName.SessionName + "-" + programmeName.ProgrammeName + ")" + tblProgrammeSession.ProgrammeSessionDetails;
                    tblProgrammeSession.ProgrammeSessionDetails = details;
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(tblProgrammeSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammeId = new SelectList(db.TblProgrammes, "ProgrammeId", "ProgrammeName", tblProgrammeSession.ProgrammeId);
            ViewBag.SessionId = new SelectList(db.TblSessions, "SessionId", "SessionName", tblProgrammeSession.SessionId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblProgrammeSession.UserId);
            return View(tblProgrammeSession);
        }

        // GET: TblProgrammeSessions/Delete/5
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
            TblProgrammeSession tblProgrammeSession = db.TblProgrammeSessions.Find(id);
            if (tblProgrammeSession == null)
            {
                return HttpNotFound();
            }
            return View(tblProgrammeSession);
        }

        // POST: TblProgrammeSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblProgrammeSession tblProgrammeSession = db.TblProgrammeSessions.Find(id);
            db.TblProgrammeSessions.Remove(tblProgrammeSession);
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
