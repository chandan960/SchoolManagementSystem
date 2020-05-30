using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class TblEmployeeEducationVM
    {
        public int UserId { get; set; }
        public Nullable<int> EmployeeResumeId { get; set; }
        public string EmployeeEducationInstitute { get; set; }
        public string EmployeeEducationTitleOfDiploma { get; set; }
        public string EmployeeEducationDegree { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EmployeeEducationFromYear { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EmployeeEducationToYear { get; set; }
        public string EmployeeEducationCity { get; set; }
        public string EmployeeEducationCountry { get; set; }

        public List<SelectListItem> EducationListOfCity { get; set; }
        public List<SelectListItem> EducationListOfCountry { get; set; }
    }
}


