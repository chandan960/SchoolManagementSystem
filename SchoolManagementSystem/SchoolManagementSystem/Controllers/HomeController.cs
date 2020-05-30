using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            try
            {
                if (email != null && password != null)
                {
                    var findUser = db.TblUsers.Where(u => u.UserEmailAddress == email && u.UserPassword == password).ToList();
                    if (findUser.Count() == 1)
                    {
                        Session["UserId"] = findUser[0].UserId;
                        Session["UserTypeId"] = findUser[0].UserTypeId;
                        Session["UserFullName"] = findUser[0].UserFullName;
                        Session["UserName"] = findUser[0].UserName;
                        Session["UserPassword"] = findUser[0].UserPassword;
                        Session["UserContactNo"] = findUser[0].UserContactNo;
                        Session["UserEmailAddress"] = findUser[0].UserEmailAddress;
                        Session["UserAddress"] = findUser[0].UserAddress;

                        string url = string.Empty;

                        if (findUser[0].UserTypeId == 1)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Login");
                        }
                    }
                    else
                    {
                        Session["UserId"] = string.Empty;
                        Session["UserTypeId"] = string.Empty;
                        Session["UserFullName"] = string.Empty;
                        Session["UserName"] = string.Empty;
                        Session["UserPassword"] = string.Empty;
                        Session["UserContactNo"] = string.Empty;
                        Session["UserEmailAddress"] = string.Empty;
                        Session["UserAddress"] = string.Empty;

                        ViewBag.message = "Email Or Password Incorrect";

                    }
                }
                else
                {
                    Session["UserId"] = string.Empty;
                    Session["UserTypeId"] = string.Empty;
                    Session["UserFullName"] = string.Empty;
                    Session["UserName"] = string.Empty;
                    Session["UserPassword"] = string.Empty;
                    Session["UserContactNo"] = string.Empty;
                    Session["UserEmailAddress"] = string.Empty;
                    Session["UserAddress"] = string.Empty;

                    ViewBag.message = "Email Or Password Missing";
                }
            }
            catch (Exception e)
            {
                Session["UserId"] = string.Empty;
                Session["UserTypeId"] = string.Empty;
                Session["UserFullName"] = string.Empty;
                Session["UserName"] = string.Empty;
                Session["UserPassword"] = string.Empty;
                Session["UserContactNo"] = string.Empty;
                Session["UserEmailAddress"] = string.Empty;
                Session["UserAddress"] = string.Empty;

                ViewBag.message = "Somethng Problem Occure";
            }
            return View("Login");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserId"] = string.Empty;
            Session["UserTypeId"] = string.Empty;
            Session["UserFullName"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["UserPassword"] = string.Empty;
            Session["UserContactNo"] = string.Empty;
            Session["UserEmailAddress"] = string.Empty;
            Session["UserAddress"] = string.Empty;

            return RedirectToAction("Login");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}