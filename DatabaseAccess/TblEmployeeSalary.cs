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

    public partial class TblEmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public double EmployeeSalaryAmount { get; set; }
        public string EmployeeSalaryMonth { get; set; }
        public string EmployeeSalaryYear { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime EmployeeSalaryDate { get; set; }
        public string EmployeeSalaryComments { get; set; }
    
        public virtual TblEmployee TblEmployee { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}
