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
    
    public partial class TblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUser()
        {
            this.TblAnnuals = new HashSet<TblAnnual>();
            this.TblDesignations = new HashSet<TblDesignation>();
            this.TblEmployees = new HashSet<TblEmployee>();
            this.TblEmployeeCertificates = new HashSet<TblEmployeeCertificate>();
            this.TblEmployeeEducations = new HashSet<TblEmployeeEducation>();
            this.TblEmployeeLanguages = new HashSet<TblEmployeeLanguage>();
            this.TblEmployeeLeavings = new HashSet<TblEmployeeLeaving>();
            this.TblEmployeeSalaries = new HashSet<TblEmployeeSalary>();
            this.TblEmployeeSkills = new HashSet<TblEmployeeSkill>();
            this.TblEmployeeWorkExperiences = new HashSet<TblEmployeeWorkExperience>();
            this.TblEvents = new HashSet<TblEvent>();
            this.TblExams = new HashSet<TblExam>();
            this.TblExamMarks = new HashSet<TblExamMark>();
            this.TblExamSettings = new HashSet<TblExamSetting>();
            this.TblExpenses = new HashSet<TblExpense>();
            this.TblExpenseTypes = new HashSet<TblExpenseType>();
            this.TblProgrammes = new HashSet<TblProgramme>();
            this.TblProgrammeSessions = new HashSet<TblProgrammeSession>();
            this.TblRooms = new HashSet<TblRoom>();
            this.TblSections = new HashSet<TblSection>();
            this.TblSessions = new HashSet<TblSession>();
            this.TblSessionProgrammeSubjectSettings = new HashSet<TblSessionProgrammeSubjectSetting>();
            this.TblStudents = new HashSet<TblStudent>();
            this.TblStudentLeavings = new HashSet<TblStudentLeaving>();
            this.TblSubjects = new HashSet<TblSubject>();
            this.TblSubmissionFees = new HashSet<TblSubmissionFee>();
            this.TblTimes = new HashSet<TblTime>();
        }
    
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserContactNo { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAnnual> TblAnnuals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblDesignation> TblDesignations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployeeCertificate> TblEmployeeCertificates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployeeEducation> TblEmployeeEducations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployeeLanguage> TblEmployeeLanguages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployeeLeaving> TblEmployeeLeavings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployeeSalary> TblEmployeeSalaries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployeeSkill> TblEmployeeSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEmployeeWorkExperience> TblEmployeeWorkExperiences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEvent> TblEvents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblExam> TblExams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblExamMark> TblExamMarks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblExamSetting> TblExamSettings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblExpense> TblExpenses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblExpenseType> TblExpenseTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProgramme> TblProgrammes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProgrammeSession> TblProgrammeSessions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblRoom> TblRooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSection> TblSections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSession> TblSessions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSessionProgrammeSubjectSetting> TblSessionProgrammeSubjectSettings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudent> TblStudents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudentLeaving> TblStudentLeavings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSubject> TblSubjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSubmissionFee> TblSubmissionFees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblTime> TblTimes { get; set; }
        public virtual TblUserType TblUserType { get; set; }
    }
}