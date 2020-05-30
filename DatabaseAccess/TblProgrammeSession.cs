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

    public partial class TblProgrammeSession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblProgrammeSession()
        {
            this.TblExamSettings = new HashSet<TblExamSetting>();
            this.TblStudentPromots = new HashSet<TblStudentPromot>();
        }
    
        public int ProgrammeSessionId { get; set; }
        public int UserId { get; set; }
        public int ProgrammeId { get; set; }
        public int SessionId { get; set; }
        public string ProgrammeSessionDetails { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ProgrammeSessionRegistrationDate { get; set; }
        public string ProgrammeSessionDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblExamSetting> TblExamSettings { get; set; }
        public virtual TblProgramme TblProgramme { get; set; }
        public virtual TblSession TblSession { get; set; }
        public virtual TblUser TblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentPromot> TblStudentPromots { get; set; }
    }
}
