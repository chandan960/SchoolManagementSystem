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
    public class TblEmployeesController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        // GET: TblEmployees
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tblEmployees = db.TblEmployees.Include(t => t.TblDesignation).Include(t => t.TblUser);
            return View(tblEmployees.ToList());
        }

        // GET: TblEmployees/Details/5
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
            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // GET: TblEmployees/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.DesignationId = new SelectList(db.TblDesignations, "DesignationId", "DesignationTitle");
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName");
            return View();
        }

        // POST: TblEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,UserId,DesignationId,EmployeeName,EmployeeContactNo,EmployeeEmailAddress,EmployeeAddress,EmployeeQualification,PhotoFile,EmployeeDescription,EmployeeBasicSalary,EmployeeStatus,EmployeeGender,EmployeeHomeContactNo,EmployeeDoYouHaveAnyDisability,EmployeeIfDisabilityYesGiveIssue,EmployeeDoYouTakingAnyMedication,EmployeeIfMedicationYesGiveIssue,EmployeeAnyCreminalOffCenceAgain,EmployeeIfCreminalOffCenceAgainYesGiveIssue,EmployeeRegistrationDate")] TblEmployee tblEmployee)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblEmployee.UserId = userId;
            tblEmployee.EmployeePhoto = "/Content/EmployeePhoto/default.png";

            if (ModelState.IsValid)
            {
                db.TblEmployees.Add(tblEmployee);
                db.SaveChanges();

                if (tblEmployee.PhotoFile != null) {
                    var folder = "/Content/EmployeePhoto";
                    var file = string.Format("{0}.png", tblEmployee.EmployeeId);
                    var response = FileHelper.UploadFile.UploadPhoto(tblEmployee.PhotoFile, folder, file);

                   if (response)
                    {
                        var pic = string.Format("{0}/{1}", folder,file);
                        tblEmployee.EmployeePhoto = pic;
                        db.Entry(tblEmployee).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(db.TblDesignations, "DesignationId", "DesignationTitle", tblEmployee.DesignationId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblEmployee.UserId);
            return View(tblEmployee);
        }

        // GET: TblEmployees/Edit/5
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
            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.TblDesignations, "DesignationId", "DesignationTitle", tblEmployee.DesignationId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblEmployee.UserId);
            return View(tblEmployee);
        }

        // POST: TblEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,UserId,DesignationId,EmployeeName,EmployeeContactNo,EmployeeEmailAddress,EmployeeAddress,EmployeeQualification,PhotoFile,EmployeeDescription,EmployeeBasicSalary,EmployeeStatus,EmployeeGender,EmployeeHomeContactNo,EmployeeDoYouHaveAnyDisability,EmployeeIfDisabilityYesGiveIssue,EmployeeDoYouTakingAnyMedication,EmployeeIfMedicationYesGiveIssue,EmployeeAnyCreminalOffCenceAgain,EmployeeIfCreminalOffCenceAgainYesGiveIssue,EmployeeRegistrationDate")] TblEmployee tblEmployee)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
            tblEmployee.UserId = userId;
            

            var folder = "/Content/EmployeePhoto";
            var file = string.Format("{0}.png", tblEmployee.EmployeeId);
            var response = FileHelper.UploadFile.UploadPhoto(tblEmployee.PhotoFile, folder, file);
            if (response)
            {
                var pic = string.Format("{0}/{1}", folder, file);
                tblEmployee.EmployeePhoto = pic;
            }
            

            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();                    

                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.TblDesignations, "DesignationId", "DesignationTitle", tblEmployee.DesignationId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "UserFullName", tblEmployee.UserId);
            return View(tblEmployee);
        }

        // GET: TblEmployees/Delete/5
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
            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: TblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            TblEmployee tblEmployee = db.TblEmployees.Find(id);
            db.TblEmployees.Remove(tblEmployee);
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
