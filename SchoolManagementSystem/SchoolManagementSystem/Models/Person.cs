using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Certificates = new HashSet<Certificate>();
            this.Educations = new HashSet<Education>();
            this.Languages = new HashSet<Language>();
            this.Skills = new HashSet<Skill>();
            this.WorkExperiences = new HashSet<WorkExperience>();
            
        }

        [Key]
        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public Nullable<System.DateTime> PersonDateOfBirth { get; set; }
        public string PersonNationality { get; set; }
        public string PersonEducationLevel { get; set; }
        public string PersonAddress { get; set; }
        public string PersonContactNo { get; set; }
        public string PersonEmail { get; set; }
        public string PersonSummary { get; set; }
        public string PersonLinkIn { get; set; }
        public string PersonFacebook { get; set; }
        public string PersonTwitter { get; set; }
        public byte[] PersonImage { get; set; }
        public Nullable<int> EmployeeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificate> Certificates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Educations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }


    }
}