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

    public partial class TblSessionProgrammeSubjectSetting
    {
        public int SessionProgrammeSubjectSettingId { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public int ClassId { get; set; }
        public int ProgrammeId { get; set; }
        public int SubjectId { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime SessionProgrammeSubjectSettingRegistrationDate { get; set; }
        public string SessionProgrammeSubjectSettingDescription { get; set; }
    
        public virtual TblClass TblClass { get; set; }
        public virtual TblProgramme TblProgramme { get; set; }
        public virtual TblSession TblSession { get; set; }
        public virtual TblSubject TblSubject { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}
