//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblEmployeeEducation
    {
        public int EmployeeEducationId { get; set; }
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
    
        public virtual TblEmployeeResume TblEmployeeResume { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}
