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

    public partial class TblTime
    {
        public int TimeId { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public int ExamId { get; set; }
        public int RoomId { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan TimeStart { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan TimeEnd { get; set; }
        public string TimeDay { get; set; }
        public bool TimeStatus { get; set; }
    
        public virtual TblExam TblExam { get; set; }
        public virtual TblRoom TblRoom { get; set; }
        public virtual TblSubject TblSubject { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}