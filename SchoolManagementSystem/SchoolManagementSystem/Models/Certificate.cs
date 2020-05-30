using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }
        public string CertificateName { get; set; }
        public string CertificateAuthority { get; set; }
        public string CertificateLevel { get; set; }
        public Nullable<System.DateTime> CertificateFromYear { get; set; }
        public Nullable<int> PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}