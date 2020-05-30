using AutoMapper;
using AutoMapper.QueryableExtensions;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using SchoolManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace SchoolManagementSystem.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IResumeRepository _resumeRepository;
        public ResumeController(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        // GET: Resume
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckCV(int ? id)
        {
            var employeeid = 0;
            if (id == null || id == 0)
            {
                int.TryParse(Convert.ToString(Session["EmployeeId"]), out employeeid);
            }
            else
            {
                employeeid = Convert.ToInt32(id);
            }
            using (DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities())
            {
                var people = db.TblEmployeeResumes.Where(p => p.EmployeeId == employeeid);
                if (people != null)
                {
                    if (people.Count() > 0)
                    {
                        return RedirectToAction("CV", new { id = employeeid });
                    }
                    else
                    {
                        return RedirectToAction("PersonnalInformtion");
                    }
                }
                else
                {
                    return RedirectToAction("PersonnalInformtion");
                }
            }
        }

        public ActionResult ViewCV(int? id)
        {
            return RedirectToAction("CV", new { id = id });
        }


        public ActionResult PersonnalInformtion()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PersonnalInformtion(TblEmployeeResumeVM model)
        {
            //Nationality
            List<SelectListItem> nationality = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Pakistan", Value = "Pakistan", Selected = true},
            };


            //Educational Level
            List<SelectListItem> educationalLevel = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Hight School", Value = "Hight School", Selected = true},
                new SelectListItem { Text = "Diploma", Value = "Diploma"},
                new SelectListItem { Text = "Bachelor's degree", Value = "Bachelor's degree"},
                new SelectListItem { Text = "Master's degree", Value = "Master's degree"},
                new SelectListItem { Text = "Doctorate", Value = "Doctorate"},
            };

            model.EmployeeResumeListOfNationality = nationality;
            model.EmployeeResumeListOfEducationLevel = educationalLevel;

            return View(model);
        }

        [HttpPost]
        [ActionName("PersonnalInformtion")]
        public ActionResult AddPersonnalInformtion(TblEmployeeResumeVM person)
        {
            var employeeid = 0;
            int.TryParse(Convert.ToString(Session["EmployeeID"]), out employeeid);

            person.EmployeeResumeDateOfBirth = DateTime.Now;

            if (ModelState.IsValid)
            {
                //Creating Mapping
                Mapper.Initialize(cfg => cfg.CreateMap<TblEmployeeResumeVM, TblEmployeeResume>());

                TblEmployeeResume personEntity = Mapper.Map<TblEmployeeResume>(person);
                personEntity.EmployeeId = employeeid;
                HttpPostedFileBase file = Request.Files["EmployeeResumeImage"];

                bool result = _resumeRepository.AddPersonnalInformation(personEntity, file);

                if (result)
                {
                    Session["EmployeeResumeId"] = _resumeRepository.GetIdPerson(person.EmployeeResumeId);
                    return RedirectToAction("Education");
                }

                else
                {
                    ViewBag.Message = "Something Wrong !";
                    return View(person);
                }

            }

            ViewBag.MessageForm = "Please Check your form before submit !";
            return View(person);

        }

        [HttpGet]
        public ActionResult Education(TblEmployeeEducationVM education)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrUpdateEducation(TblEmployeeEducationVM education)
        {
            try
            {


                string msg = string.Empty;

                if (education != null)
                {
                    //Creating Mapping
                    Mapper.Reset();
                    Mapper.Initialize(cfg => cfg.CreateMap<TblEmployeeEducationVM, TblEmployeeEducation>());
                    TblEmployeeEducation educationEntity = Mapper.Map<TblEmployeeEducation>(education);

                    int EmployeeResumeId = (int)Session["EmployeeResumeId"];

                    msg = _resumeRepository.AddOrUpdateEducation(educationEntity, EmployeeResumeId);

                }
                else
                {
                    msg = "Please re try the operation";
                }

                return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { data = "Undefined! please Try Again!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult EducationPartial(TblEmployeeEducationVM education)
        {

            education.EducationListOfCountry = GetCountries();

            return PartialView("~/Views/Shared/_MyEducation.cshtml", education);
        }

        [HttpGet]
        public ActionResult WorkExperience()
        {
            return View();
        }

        public PartialViewResult WorkExperiencePartial(TblEmployeeWorkExperienceVM workExperience)
        {
            workExperience.WorkExperienceListOfCountry = GetCountries();

            return PartialView("~/Views/Shared/_MyWorkExperience.cshtml", workExperience);
        }

        public ActionResult AddOrUpdateExperience(TblEmployeeWorkExperienceVM workExperience)
        {

            string msg = string.Empty;

            if (workExperience != null)
            {
                //Creating Mapping
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<TblEmployeeWorkExperienceVM, TblEmployeeWorkExperience>());
                TblEmployeeWorkExperience workExperienceEntity = Mapper.Map<TblEmployeeWorkExperience>(workExperience);

                int EmployeeResumeId = (int)Session["EmployeeResumeId"];


                msg = _resumeRepository.AddOrUpdateExperience(workExperienceEntity, EmployeeResumeId);

            }
            else
            {
                msg = "Please re try the operation";
            }

            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SkiCerfLang()
        {
            return View();
        }

        public PartialViewResult SkillsPartial()
        {
            return PartialView("~/Views/Shared/_MySkills.cshtml");
        }

        public ActionResult AddSkill(TblEmployeeSkillVM skill)
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];
            string msg = string.Empty;

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<TblEmployeeSkillVM, TblEmployeeSkill>());
            TblEmployeeSkill skillEntity = Mapper.Map<TblEmployeeSkill>(skill);

            if (_resumeRepository.AddSkill(skillEntity, EmployeeResumeId))
            {
                msg = "skill added successfully";
            }
            else
            {
                msg = "something Wrong";
            }

            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult CertificatesPartial(TblEmployeeCertificateVM certificate)
        {
            List<SelectListItem> certificateLevel = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Beginner", Value = "Beginner", Selected = true},
                new SelectListItem { Text = "Intermediate", Value = "Intermediate"},
                new SelectListItem { Text = "Advanced", Value = "Advanced"}
            };

            certificate.CertificateListOfLevel = certificateLevel;

            return PartialView("~/Views/Shared/_MyCertifications.cshtml", certificate);
        }

        public ActionResult AddCertification(TblEmployeeCertificateVM certificate)
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];
            string msg = string.Empty;

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<TblEmployeeCertificateVM, TblEmployeeCertificate>());
            TblEmployeeCertificate certificateEntity = Mapper.Map<TblEmployeeCertificate>(certificate);

            if (_resumeRepository.AddCertificate(certificateEntity, EmployeeResumeId))
            {
                msg = "Certification added successfully";
            }
            else
            {
                msg = "something Wrong";
            }

            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult LanguagePartial(TblEmployeeLanguageVM language)
        {
            List<SelectListItem> languageLevel = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Elementary Proficiency", Value = "Elementary Proficiency", Selected = true},
                new SelectListItem { Text = "LimitedWorking Proficiency", Value = "LimitedWorking Proficiency"},
                new SelectListItem { Text = "Professional working Proficiency", Value = "Professional working Proficiency"},
                new SelectListItem { Text = "Full Professional Proficiency", Value = "Full Professional Proficiency"},
                new SelectListItem { Text = "Native Or Bilingual Proficiency", Value = "Native Or Bilingual Proficiency"}
            };

            language.LanguageListOfProficiency = languageLevel;

            return PartialView("~/Views/Shared/_MyLanguage.cshtml", language);
        }

        public ActionResult AddLanguage(TblEmployeeLanguageVM language)
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];
            string msg = string.Empty;

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<TblEmployeeLanguageVM, TblEmployeeLanguage>());
            TblEmployeeLanguage languageEntity = Mapper.Map<TblEmployeeLanguage>(language);

            if (_resumeRepository.AddLanguage(languageEntity, EmployeeResumeId))
            {
                msg = "Language added successfully";
            }
            else
            {
                msg = "something Wrong";
            }

            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CV(int? EmployeeId)
        {
            using (DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities())
            {
                var person = db.TblEmployeeResumes.Where(p => p.EmployeeId == EmployeeId).FirstOrDefault();
                Session["EmployeeResumeId"] = person.EmployeeResumeId;
                return View();
            }


        }

        public PartialViewResult GetPersonnalInfoPartial()
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];
            TblEmployeeResume person = _resumeRepository.GetPersonnalInfo(EmployeeResumeId);

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<TblEmployeeResume, TblEmployeeResumeVM>());
            TblEmployeeResumeVM personVM = Mapper.Map<TblEmployeeResumeVM>(person);

            return PartialView("~/Views/Shared/_MyPersonnalInfo.cshtml", personVM);
        }

        public PartialViewResult GetEducationCVPartial()
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Education, TblEmployeeEducationVM>());
            IQueryable<TblEmployeeEducationVM> educationList = _resumeRepository.GetEducationById(EmployeeResumeId).ProjectTo<TblEmployeeEducationVM>().AsQueryable();

            return PartialView("~/Views/Shared/_MyEducationCV.cshtml", educationList);
        }

        public PartialViewResult WorkExperienceCVPartial()
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<WorkExperience, TblEmployeeWorkExperienceVM>());
            IQueryable<TblEmployeeWorkExperienceVM> workExperienceList = _resumeRepository.GetWorkExperienceById(EmployeeResumeId).ProjectTo<TblEmployeeWorkExperienceVM>().AsQueryable();


            return PartialView("~/Views/Shared/_WorkExperienceCV.cshtml", workExperienceList);
        }

        public PartialViewResult SkillCVPartial()
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Skill, TblEmployeeSkillVM>());
            IQueryable<TblEmployeeSkillVM> skillsList = _resumeRepository.GetSkillById(EmployeeResumeId).ProjectTo<TblEmployeeSkillVM>().AsQueryable();


            return PartialView("~/Views/Shared/_MySkillsCV.cshtml", skillsList);
        }

        public PartialViewResult CertificateCVPartial()
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Certificate, TblEmployeeCertificateVM>());
            IQueryable<TblEmployeeCertificateVM> certificateList = _resumeRepository.GetCertificateById(EmployeeResumeId).ProjectTo<TblEmployeeCertificateVM>().AsQueryable();


            return PartialView("~/Views/Shared/_MyCertificationCV.cshtml", certificateList);
        }

        public PartialViewResult LanguageCVPartial()
        {
            int EmployeeResumeId = (int)Session["EmployeeResumeId"];

            //Creating Mapping
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Language, TblEmployeeLanguageVM>());
            IQueryable<TblEmployeeLanguageVM> languageList = _resumeRepository.GetLanguageById(EmployeeResumeId).ProjectTo<TblEmployeeLanguageVM>().AsQueryable();


            return PartialView("~/Views/Shared/_MyLanguageCV.cshtml", languageList);
        }

        public ActionResult GetProfilImage(int id)
        {
            //byte[] image = _resumeRepository.GetPersonnalInfo(id).EmployeeResumeImage;
            string image = _resumeRepository.GetPersonnalInfo(id).EmployeeResumeImage;
            if (image != null)
            {
                return File(image, "image/png");
            }
            else
            {
                return null;
            }

        }

        public ActionResult GetCities(string country)
        {
            List<SelectListItem> listOfCities = new List<SelectListItem>();


            switch (country)
            {
                case "Pakistan":
                    listOfCities.Add(new SelectListItem() { Text = "KPK", Value = "KPK", Selected = true });
                    listOfCities.Add(new SelectListItem() { Text = "Punjab", Value = "Punjab" });
                    listOfCities.Add(new SelectListItem() { Text = "Sindh", Value = "Sindh" });
                    listOfCities.Add(new SelectListItem() { Text = "Balochistan", Value = "Balochistan" });
                    break;

                case "India":
                    listOfCities.Add(new SelectListItem() { Text = "Bombay", Value = "Bombay", Selected = true });
                    listOfCities.Add(new SelectListItem() { Text = "Bangalore", Value = "Bangalore" });
                    listOfCities.Add(new SelectListItem() { Text = "Chennai", Value = "Chennai" });
                    listOfCities.Add(new SelectListItem() { Text = "Hyderabad", Value = "Hyderabad" });
                    break;

                case "Spain":
                    listOfCities.Add(new SelectListItem() { Text = "Barcelone", Value = "Barcelone", Selected = true });
                    listOfCities.Add(new SelectListItem() { Text = "Madrid", Value = "Madrid" });
                    listOfCities.Add(new SelectListItem() { Text = "Valence", Value = "Valence" });
                    listOfCities.Add(new SelectListItem() { Text = "Malaga", Value = "Malaga" });
                    break;

                case "USA":
                    listOfCities.Add(new SelectListItem() { Text = "New York", Value = "New York", Selected = true });
                    listOfCities.Add(new SelectListItem() { Text = "Los Angeles", Value = "Los Angeles" });
                    listOfCities.Add(new SelectListItem() { Text = "San Francisco", Value = "San Francisco" });
                    listOfCities.Add(new SelectListItem() { Text = "Chicago", Value = "Chicago" });
                    break;
            }

            return Json(new { data = listOfCities }, JsonRequestBehavior.AllowGet);
        }

        public List<SelectListItem> GetCountries()
        {
            List<SelectListItem> listOfCountry = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Pakistan", Value = "Pakistan", Selected = true},
                new SelectListItem() { Text = "Morocco", Value = "Morocco" },
                new SelectListItem() { Text = "India", Value = "India"},
                new SelectListItem() { Text = "Spain", Value = "Spain"},
                new SelectListItem() { Text = "USA", Value = "USA"}
            };

            return listOfCountry;
        }

    }
}
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using SchoolManagementSystem.Models;
//using SchoolManagementSystem.Repository;
//using SchoolManagementSystem.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace SchoolManagementSystem.Controllers
//{
//    public class ResumeController : Controller
//    {
//        private readonly IResumeRepository _resumeRepository;
//        public ResumeController(IResumeRepository resumeRepository)
//        {
//            _resumeRepository = resumeRepository;
//        }

//        // GET: Resume
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult CheckCV()
//        {
//            var employeeid = 0;
//            int.TryParse(Convert.ToString(Session["EmployeeID"]), out employeeid);
//            using (DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities())
//            {
//                var people = db.TblEmployeeResumes.Where(p => p.EmployeeId == employeeid);
//                if (people != null)
//                {
//                    if (people.Count() > 0)
//                    {
//                        return RedirectToAction("CV", new { id = employeeid });
//                    }
//                    else
//                    {
//                        return RedirectToAction("PersonnalInformtion");
//                    }
//                }
//                else
//                {
//                    return RedirectToAction("PersonnalInformtion");
//                }
//            }
//        }

//        public ActionResult ViewCV(int? id)
//        {
//            return RedirectToAction("CV", new { id = id });
//        }


//        public ActionResult PersonnalInformtion()
//        {
//            return View();
//        }


//        [HttpGet]
//        public ActionResult PersonnalInformtion(PersonVM model)
//        {
//            //Nationality
//            List<SelectListItem> nationality = new List<SelectListItem>()
//            {
//                new SelectListItem { Text = "Pakistan", Value = "Pakistan", Selected = true},
//            };


//            //Educational Level
//            List<SelectListItem> educationalLevel = new List<SelectListItem>()
//            {
//                new SelectListItem { Text = "Hight School", Value = "Hight School", Selected = true},
//                new SelectListItem { Text = "Diploma", Value = "Diploma"},
//                new SelectListItem { Text = "Bachelor's degree", Value = "Bachelor's degree"},
//                new SelectListItem { Text = "Master's degree", Value = "Master's degree"},
//                new SelectListItem { Text = "Doctorate", Value = "Doctorate"},
//            };

//            model.PersonListOfNationality = nationality;
//            model.PersonListOfEducationLevel = educationalLevel;

//            return View(model);
//        }

//        [HttpPost]
//        [ActionName("PersonnalInformtion")]
//        public ActionResult AddPersonnalInformtion(PersonVM person)
//        {
//            var employeeid = 0;
//            int.TryParse(Convert.ToString(Session["EmployeeID"]), out employeeid);

//            person.PersonDateOfBirth = DateTime.Now;

//            if (ModelState.IsValid)
//            {
//                //Creating Mapping
//                Mapper.Initialize(cfg => cfg.CreateMap<PersonVM, Person>());

//                Person personEntity = Mapper.Map<Person>(person);
//                personEntity.EmployeeId = employeeid;
//                HttpPostedFileBase file = Request.Files["PersonImage"];

//                bool result = _resumeRepository.AddPersonnalInformation(personEntity, file);

//                if (result)
//                {
//                    Session["IdSelected"] = _resumeRepository.GetIdPerson(person.PersonFirstName, person.PersonLastName);
//                    return RedirectToAction("Education");
//                }
//                else
//                {
//                    ViewBag.Message = "Something Wrong !";
//                    return View(person);
//                }

//            }

//            ViewBag.MessageForm = "Please Check your form before submit !";
//            return View(person);

//        }

//        [HttpGet]
//        public ActionResult Education(EducationVM education)
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult AddOrUpdateEducation(EducationVM education)
//        {
//            try
//            {


//                string msg = string.Empty;

//                if (education != null)
//                {
//                    //Creating Mapping
//                    Mapper.Reset();
//                    Mapper.Initialize(cfg => cfg.CreateMap<EducationVM, Education>());
//                    Education educationEntity = Mapper.Map<Education>(education);

//                    int idPer = (int)Session["IdSelected"];

//                    msg = _resumeRepository.AddOrUpdateEducation(educationEntity, idPer);

//                }
//                else
//                {
//                    msg = "Please re try the operation";
//                }

//                return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception ex)
//            {

//                return Json(new { data = "Undefined! please Try Again!" }, JsonRequestBehavior.AllowGet);
//            }
//        }

//        [HttpGet]
//        public PartialViewResult EducationPartial(EducationVM education)
//        {

//            education.EducationListOfCountry = GetCountries();

//            return PartialView("~/Views/Shared/_MyEducation.cshtml", education);
//        }

//        [HttpGet]
//        public ActionResult WorkExperience()
//        {
//            return View();
//        }

//        public PartialViewResult WorkExperiencePartial(WorkExperienceVM workExperience)
//        {
//            workExperience.WorkExperienceListOfCountry = GetCountries();

//            return PartialView("~/Views/Shared/_MyWorkExperience.cshtml", workExperience);
//        }

//        public ActionResult AddOrUpdateExperience(WorkExperienceVM workExperience)
//        {

//            string msg = string.Empty;

//            if (workExperience != null)
//            {
//                //Creating Mapping
//                Mapper.Reset();
//                Mapper.Initialize(cfg => cfg.CreateMap<WorkExperienceVM, WorkExperience>());
//                WorkExperience workExperienceEntity = Mapper.Map<WorkExperience>(workExperience);

//                int idPer = (int)Session["IdSelected"];


//                msg = _resumeRepository.AddOrUpdateExperience(workExperienceEntity, idPer);

//            }
//            else
//            {
//                msg = "Please re try the operation";
//            }

//            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public ActionResult SkiCerfLang()
//        {
//            return View();
//        }

//        public PartialViewResult SkillsPartial()
//        {
//            return PartialView("~/Views/Shared/_MySkills.cshtml");
//        }

//        public ActionResult AddSkill(SkillVM skill)
//        {
//            int idPer = (int)Session["IdSelected"];
//            string msg = string.Empty;

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<SkillVM, Skill>());
//            Skill skillEntity = Mapper.Map<Skill>(skill);

//            if (_resumeRepository.AddSkill(skillEntity, idPer))
//            {
//                msg = "skill added successfully";
//            }
//            else
//            {
//                msg = "something Wrong";
//            }

//            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
//        }

//        public PartialViewResult CertificatesPartial(CertificateVM certificate)
//        {
//            List<SelectListItem> certificateLevel = new List<SelectListItem>()
//            {
//                new SelectListItem { Text = "Beginner", Value = "Beginner", Selected = true},
//                new SelectListItem { Text = "Intermediate", Value = "Intermediate"},
//                new SelectListItem { Text = "Advanced", Value = "Advanced"}
//            };

//            certificate.CertificateListOfLevel = certificateLevel;

//            return PartialView("~/Views/Shared/_MyCertifications.cshtml", certificate);
//        }

//        public ActionResult AddCertification(CertificateVM certificate)
//        {
//            int idPer = (int)Session["IdSelected"];
//            string msg = string.Empty;

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<CertificateVM, Certificate>());
//            Certificate certificateEntity = Mapper.Map<Certificate>(certificate);

//            if (_resumeRepository.AddCertificate(certificateEntity, idPer))
//            {
//                msg = "Certification added successfully";
//            }
//            else
//            {
//                msg = "something Wrong";
//            }

//            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
//        }

//        public PartialViewResult LanguagePartial(LanguageVM language)
//        {
//            List<SelectListItem> languageLevel = new List<SelectListItem>()
//            {
//                new SelectListItem { Text = "Elementary Proficiency", Value = "Elementary Proficiency", Selected = true},
//                new SelectListItem { Text = "LimitedWorking Proficiency", Value = "LimitedWorking Proficiency"},
//                new SelectListItem { Text = "Professional working Proficiency", Value = "Professional working Proficiency"},
//                new SelectListItem { Text = "Full Professional Proficiency", Value = "Full Professional Proficiency"},
//                new SelectListItem { Text = "Native Or Bilingual Proficiency", Value = "Native Or Bilingual Proficiency"}
//            };

//            language.LanguageListOfProficiency = languageLevel;

//            return PartialView("~/Views/Shared/_MyLanguage.cshtml", language);
//        }

//        public ActionResult AddLanguage(LanguageVM language)
//        {
//            int idPer = (int)Session["IdSelected"];
//            string msg = string.Empty;

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<LanguageVM, Language>());
//            Language languageEntity = Mapper.Map<Language>(language);

//            if (_resumeRepository.AddLanguage(languageEntity, idPer))
//            {
//                msg = "Language added successfully";
//            }
//            else
//            {
//                msg = "something Wrong";
//            }

//            return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
//        }

//        public ActionResult CV(int? id)
//        {
//            using (DbSchoolManagementSystemEntities db = new DbSchoolManagementSystemEntities())
//            {
//                var person = db.TblEmployeeResumes.Where(p => p.EmployeeId == id).FirstOrDefault();
//                id = person.EmployeeId;
//            }



//            Session["IdSelected"] = id;
//            return View();
//        }

//        public PartialViewResult GetPersonnalInfoPartial()
//        {
//            int idPer = (int)Session["IdSelected"];
//            Person person = _resumeRepository.GetPersonnalInfo(idPer);

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<Person, PersonVM>());
//            PersonVM personVM = Mapper.Map<PersonVM>(person);

//            return PartialView("~/Views/Shared/_MyPersonnalInfo.cshtml", personVM);
//        }

//        public PartialViewResult GetEducationCVPartial()
//        {
//            int idPer = (int)Session["IdSelected"];

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<Education, EducationVM>());
//            IQueryable<EducationVM> educationList = _resumeRepository.GetEducationById(idPer).ProjectTo<EducationVM>().AsQueryable();

//            return PartialView("~/Views/Shared/_MyEducationCV.cshtml", educationList);
//        }

//        public PartialViewResult WorkExperienceCVPartial()
//        {
//            int idPer = (int)Session["IdSelected"];

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<WorkExperience, WorkExperienceVM>());
//            IQueryable<WorkExperienceVM> workExperienceList = _resumeRepository.GetWorkExperienceById(idPer).ProjectTo<WorkExperienceVM>().AsQueryable();


//            return PartialView("~/Views/Shared/_WorkExperienceCV.cshtml", workExperienceList);
//        }

//        public PartialViewResult SkillsCVPartial()
//        {
//            int idPer = (int)Session["IdSelected"];

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<Skill, SkillVM>());
//            IQueryable<SkillVM> skillsList = _resumeRepository.GetSkillById(idPer).ProjectTo<SkillVM>().AsQueryable();


//            return PartialView("~/Views/Shared/_MySkillsCV.cshtml", skillsList);
//        }

//        public PartialViewResult CertificationsCVPartial()
//        {
//            int idPer = (int)Session["IdSelected"];

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<Certificate, CertificateVM>());
//            IQueryable<CertificateVM> certificateList = _resumeRepository.GetCertificateById(idPer).ProjectTo<CertificateVM>().AsQueryable();


//            return PartialView("~/Views/Shared/_MyCertificationCV.cshtml", certificateList);
//        }

//        public PartialViewResult LanguageCVPartial()
//        {
//            int idPer = (int)Session["IdSelected"];

//            //Creating Mapping
//            Mapper.Reset();
//            Mapper.Initialize(cfg => cfg.CreateMap<Language, LanguageVM>());
//            IQueryable<LanguageVM> languageList = _resumeRepository.GetLanguageById(idPer).ProjectTo<LanguageVM>().AsQueryable();


//            return PartialView("~/Views/Shared/_MyLanguageCV.cshtml", languageList);
//        }

//        public ActionResult GetProfilImage(int id)
//        {
//            byte[] image = _resumeRepository.GetPersonnalInfo(id).PersonImage;
//            if (image != null)
//            {
//                return File(image, "image/png");
//            }
//            else
//            {
//                return null;
//            }

//        }

//        public ActionResult GetCities(string country)
//        {
//            List<SelectListItem> listOfCities = new List<SelectListItem>();


//            switch (country)
//            {
//                case "Pakistan":
//                    listOfCities.Add(new SelectListItem() { Text = "KPK", Value = "KPK", Selected = true });
//                    listOfCities.Add(new SelectListItem() { Text = "Punjab", Value = "Punjab" });
//                    listOfCities.Add(new SelectListItem() { Text = "Sindh", Value = "Sindh" });
//                    listOfCities.Add(new SelectListItem() { Text = "Balochistan", Value = "Balochistan" });
//                    break;

//                case "India":
//                    listOfCities.Add(new SelectListItem() { Text = "Bombay", Value = "Bombay", Selected = true });
//                    listOfCities.Add(new SelectListItem() { Text = "Bangalore", Value = "Bangalore" });
//                    listOfCities.Add(new SelectListItem() { Text = "Chennai", Value = "Chennai" });
//                    listOfCities.Add(new SelectListItem() { Text = "Hyderabad", Value = "Hyderabad" });
//                    break;

//                case "Spain":
//                    listOfCities.Add(new SelectListItem() { Text = "Barcelone", Value = "Barcelone", Selected = true });
//                    listOfCities.Add(new SelectListItem() { Text = "Madrid", Value = "Madrid" });
//                    listOfCities.Add(new SelectListItem() { Text = "Valence", Value = "Valence" });
//                    listOfCities.Add(new SelectListItem() { Text = "Malaga", Value = "Malaga" });
//                    break;

//                case "USA":
//                    listOfCities.Add(new SelectListItem() { Text = "New York", Value = "New York", Selected = true });
//                    listOfCities.Add(new SelectListItem() { Text = "Los Angeles", Value = "Los Angeles" });
//                    listOfCities.Add(new SelectListItem() { Text = "San Francisco", Value = "San Francisco" });
//                    listOfCities.Add(new SelectListItem() { Text = "Chicago", Value = "Chicago" });
//                    break;
//            }

//            return Json(new { data = listOfCities }, JsonRequestBehavior.AllowGet);
//        }

//        public List<SelectListItem> GetCountries()
//        {
//            List<SelectListItem> listOfCountry = new List<SelectListItem>()
//            {
//                 new SelectListItem() { Text = "Pakistan", Value = "Pakistan", Selected = true},
//                new SelectListItem() { Text = "Morocco", Value = "Morocco" },
//                new SelectListItem() { Text = "India", Value = "India"},
//                new SelectListItem() { Text = "Spain", Value = "Spain"},
//                new SelectListItem() { Text = "USA", Value = "USA"}
//            };

//            return listOfCountry;
//        }

//    }
//}

