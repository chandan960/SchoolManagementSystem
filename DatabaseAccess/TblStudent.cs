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

    public partial class TblStudent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblStudent()
        {
            this.TblExamMarks = new HashSet<TblExamMark>();
            this.TblStudentPromots = new HashSet<TblStudentPromot>();
            this.TblStudentAttendances = new HashSet<TblStudentAttendance>();
            this.TblStudentLeavings = new HashSet<TblStudentLeaving>();
            this.TblSubmissionFees = new HashSet<TblSubmissionFee>();
        }
    
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public int ProgrammeId { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public string StudentName { get; set; }
        public string StudentFatherName { get; set; }
        public string StudentMotherName { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime StudentDateOfBirth { get; set; }
        public string StudentGender { get; set; }
        public string StudentContactNo { get; set; }
        public string StudentCNIC { get; set; }
        public string StudentFNIC { get; set; }
        public string StudentPhoto { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime StudentAdmissionDate { get; set; }
        public string StudentPreviousSchool { get; set; }
        public Nullable<double> StudentPreviousPercentage { get; set; }
        public string StudentEmailAddress { get; set; }
        public string StudentAddress { get; set; }
        public string StudentReligion { get; set; }
        public string StudentTribeorCaste { get; set; }
        public string StudentGuardiansOccupationOfProfession { get; set; }
        public string StudentGuardiansAddress { get; set; }
        public string StudentGuardiansContactNoOffice { get; set; }
        public string StudentGuardiansContactNoResident { get; set; }
    
        public virtual TblClass TblClass { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblExamMark> TblExamMarks { get; set; }
        public virtual TblProgramme TblProgramme { get; set; }
        public virtual TblSession TblSession { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentPromot> TblStudentPromots { get; set; }
        public virtual TblUser TblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentAttendance> TblStudentAttendances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentLeaving> TblStudentLeavings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSubmissionFee> TblSubmissionFees { get; set; }
    }
}