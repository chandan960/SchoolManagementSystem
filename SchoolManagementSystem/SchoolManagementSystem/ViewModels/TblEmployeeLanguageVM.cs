using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class TblEmployeeLanguageVM
    {
        public int EmployeeLanguageId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> EmployeeResumeId { get; set; }
        public string EmployeeLanguageName { get; set; }
        public string EmployeeLanguageProficiency { get; set; }

        public List<SelectListItem> LanguageListOfProficiency { get; set; }

    }
}