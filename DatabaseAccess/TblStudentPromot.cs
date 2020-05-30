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

    public partial class TblStudentPromot
    {
        public int StudentPromotId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int ProgrammeSessionId { get; set; }
        public int SectionId { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime StudentPromotDate { get; set; }
        public double StudentPromotAnnualFees { get; set; }
        public Nullable<bool> StudentPromotStatus { get; set; }
        public Nullable<bool> StudentPromotSubmit { get; set; }
    
        public virtual TblClass TblClass { get; set; }
        public virtual TblProgrammeSession TblProgrammeSession { get; set; }
        public virtual TblSection TblSection { get; set; }
        public virtual TblSession TblSession { get; set; }
        public virtual TblStudent TblStudent { get; set; }
    }
}