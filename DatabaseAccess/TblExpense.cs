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

    public partial class TblExpense
    {
        public int ExpenseId { get; set; }
        public int ExpenseTypeId { get; set; }
        public Nullable<int> UserId { get; set; }
        public double ExpenseAmount { get; set; }
        public string ExpenseInvoiceNo { get; set; }
        public string ExpenseReason { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ExpenseDate { get; set; }
        public string ExpenseDescrption { get; set; }
    
        public virtual TblExpenseType TblExpenseType { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}
