using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class TblEmployeeResumeVM
    {
        public int EmployeeResumeId { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        public string EmployeeResumeFirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        public string EmployeeResumeLastName { get; set; }
        [Required(ErrorMessage = "Date Of Birth Required")]
        public Nullable<System.DateTime> EmployeeResumeDateOfBirth { get; set; }
        [Required(ErrorMessage = "Nationality Required")]
        public string EmployeeResumeNationality { get; set; }
        [Required(ErrorMessage = "Education Level Required")]
        public string EmployeeResumeEducationLevel { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string EmployeeResumeAddress { get; set; }
        [Required(ErrorMessage = "Contact No Required")]
        public string EmployeeResumeContactNo { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string EmployeeResumeEmail { get; set; }
        [Required(ErrorMessage = "Summary Required")]
        [DataType(DataType.MultilineText)]
        public string EmployeeResumeSummary { get; set; }
        [Required(ErrorMessage = "LinkIn Link Required")]
        [DataType(DataType.Url)]
        public string EmployeeResumeLinkIn { get; set; }
        [Required(ErrorMessage = "Facebook Link Required")]
        [DataType(DataType.Url)]
        public string EmployeeResumeFacebook { get; set; }
        [Required(ErrorMessage = "Twitter Link Required")]
        [DataType(DataType.Url)]
        public string EmployeeResumeTwitter { get; set; }
        public byte[] EmployeeResumeImage { get; set; }

        public List<SelectListItem> EmployeeResumeListOfNationality { get; set; }
        public List<SelectListItem> EmployeeResumeListOfEducationLevel { get; set; }
    }
}