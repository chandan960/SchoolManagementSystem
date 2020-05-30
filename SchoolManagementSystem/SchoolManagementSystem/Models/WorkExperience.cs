using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class WorkExperience
    {
        [Key]
        public int WorkExperienceId { get; set; }
        public string WorkExperienceCompany { get; set; }
        public string WorkExperienceTitle { get; set; }
        public string WorkExperienceCountry { get; set; }
        public Nullable<System.DateTime> WorkExperienceFromYear { get; set; }
        public Nullable<System.DateTime> WorkExperienceToYear { get; set; }
        public string WorkExperienceDescription { get; set; }
        public Nullable<int> PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}