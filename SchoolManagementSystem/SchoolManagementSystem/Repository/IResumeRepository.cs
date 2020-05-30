using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DatabaseAccess;

namespace SchoolManagementSystem.Repository
{
    public interface IResumeRepository
    {
        bool AddPersonnalInformation(TblEmployeeResume person, HttpPostedFileBase file);
        string AddOrUpdateEducation(TblEmployeeEducation education, int EmployeeResumeId);
        int GetIdPerson(int EmployeeId);
        string AddOrUpdateExperience(TblEmployeeWorkExperience workExperience, int EmployeeResumeId);
        bool AddSkill(TblEmployeeSkill skill, int EmployeeResumeId);
        bool AddCertificate(TblEmployeeCertificate certificate, int EmployeeResumeId);
        bool AddLanguage(TblEmployeeLanguage language, int EmployeeResumeId);
        TblEmployeeResume GetPersonnalInfo(int EmployeeId);
        IQueryable<TblEmployeeEducation> GetEducationById(int EmployeeResumeId);
        IQueryable<TblEmployeeWorkExperience> GetWorkExperienceById(int EmployeeResumeId);
        IQueryable<TblEmployeeSkill> GetSkillById(int EmployeeResumeId);
        IQueryable<TblEmployeeCertificate> GetCertificateById(int EmployeeResumeId);
        IQueryable<TblEmployeeLanguage> GetLanguageById(int EmployeeResumeId);


    }
}
