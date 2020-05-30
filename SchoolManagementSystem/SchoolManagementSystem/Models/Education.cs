using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public string EducationInstitute { get; set; }
        public string EducationTitleOfDiploma { get; set; }
        public string EducationDegree { get; set; }
        public Nullable<System.DateTime> EducationFromYear { get; set; }
        public Nullable<System.DateTime> EducationToYear { get; set; }
        public string EducationCity { get; set; }
        public string EducationCountry { get; set; }
        public Nullable<int> PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}