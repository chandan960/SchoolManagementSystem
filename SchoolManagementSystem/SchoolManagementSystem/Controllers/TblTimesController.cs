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
    public class TblTimesController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblTimes
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblTimes = db.TblTimes.Include(t => t.TblExam).Include(t => t.TblRoom).Include(t => t.TblSubject).Include(t => t.TblUser);
            return View(tblTimes.ToList());
        }

        // GET: TblTimes/Details/5
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
            TblTime tblTime = db.TblTimes.Find(id);
            if (tblTime == null)
            {
                return HttpNotFound();
            }
            return View(tblTime);
        }

        // GET: TblTimes/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle");
            ViewBag.RoomId = new SelectList(db.TblRooms, "RoomId", "RoomTitle");
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName");
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeId,UserId,SubjectId,ExamId,RoomId,TimeStart,TimeEnd,TimeDay,TimeStatus")] TblTime tblTime)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblTime.UserId = userId;

            if (ModelState.IsValid)
            {
                db.TblTimes.Add(tblTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle", tblTime.ExamId);
            ViewBag.RoomId = new SelectList(db.TblRooms, "RoomId", "RoomTitle", tblTime.RoomId);
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName", tblTime.SubjectId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblTime.UserId);
            return View(tblTime);
        }

        // GET: TblTimes/Edit/5
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
            TblTime tblTime = db.TblTimes.Find(id);
            if (tblTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle", tblTime.ExamId);
            ViewBag.RoomId = new SelectList(db.TblRooms, "RoomId", "RoomTitle", tblTime.RoomId);
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName", tblTime.SubjectId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblTime.UserId);
            return View(tblTime);
        }

        // POST: TblTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeId,UserId,SubjectId,ExamId,RoomId,TimeStart,TimeEnd,TimeDay,TimeStatus")] TblTime tblTime)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblTime.UserId = userId;

            if (ModelState.IsValid)
            {
                db.Entry(tblTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamId = new SelectList(db.TblExams, "ExamId", "ExamTitle", tblTime.ExamId);
            ViewBag.RoomId = new SelectList(db.TblRooms, "RoomId", "RoomTitle", tblTime.RoomId);
            ViewBag.SubjectId = new SelectList(db.TblSubjects, "SubjectId", "SubjectName", tblTime.SubjectId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblTime.UserId);
            return View(tblTime);
        }

        // GET: TblTimes/Delete/5
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
            TblTime tblTime = db.TblTimes.Find(id);
            if (tblTime == null)
            {
                return HttpNotFound();
            }
            return View(tblTime);
        }

        // POST: TblTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblTime tblTime = db.TblTimes.Find(id);
            db.TblTimes.Remove(tblTime);
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
