using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.ViewModels
{
    public class TblEmployeeSkillVM
    {
        public int EmployeeSkillId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> EmployeeResumeId { get; set; }
        public string EmployeeSkillName { get; set; }


    }
}