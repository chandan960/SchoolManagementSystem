using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class TblEmployeeCertificateVM
    {
        public int EmployeeCertificateId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> EmployeeResumeId { get; set; }
        public string EmployeeCertificateName { get; set; }
        public string EmployeeCertificateAuthority { get; set; }
        public string EmployeeCertificateLevel { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EmployeeCertificateFromYear { get; set; }

        public List<SelectListItem> CertificateListOfLevel { get; set; }
        
    }
}