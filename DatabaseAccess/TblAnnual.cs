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
    
    public partial class TblAnnual
    {
        public int AnnualId { get; set; }
        public int UserId { get; set; }
        public int ProgrammeId { get; set; }
        public string AnnualTitle { get; set; }
        public string AnnualDescription { get; set; }
        public Nullable<double> AnnualFees { get; set; }
        public bool AnnualStatus { get; set; }
    
        public virtual TblProgramme TblProgramme { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}
