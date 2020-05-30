using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageProficiency { get; set; }
        public Nullable<int> PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}