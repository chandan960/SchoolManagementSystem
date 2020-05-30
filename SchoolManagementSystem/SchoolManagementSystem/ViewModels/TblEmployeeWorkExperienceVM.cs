using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class TblEmployeeWorkExperienceVM
    {
        public int EmployeeWorkExperienceId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> EmployeeResumeId { get; set; }
        public string EmployeeWorkExperienceCompany { get; set; }
        public string EmployeeWorkExperienceTitle { get; set; }
        public string EmployeeWorkExperienceCountry { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EmployeeWorkExperienceFromYear { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EmployeeWorkExperienceToYear { get; set; }
        public string EmployeeWorkExperienceDescription { get; set; }

        //public int WorkExperienceId { get; set; }
        //[Required(ErrorMessage = "Company Name Required")]
        //public string WorkExperienceCompany { get; set; }
        //[Required(ErrorMessage = "Work Experience Title Required")]
        //public string WorkExperienceTitle { get; set; }
        //[Required(ErrorMessage = "Work Experience Country Required")]
        //public string WorkExperienceCountry { get; set; }
        //[Required(ErrorMessage = "Work Experience Start Date Required")]
        //public Nullable<System.DateTime> WorkExperienceFromYear { get; set; }
        //[Required(ErrorMessage = "Work Experience End Date Required")]
        //public Nullable<System.DateTime> WorkExperienceToYear { get; set; }
        //[Required(ErrorMessage = "Work Experience Description Required")]
        //[DataType(DataType.MultilineText)]
        //public string WorkExperienceDescription { get; set; }

        public List<SelectListItem> WorkExperienceListOfCountry { get; set; }


    }
}