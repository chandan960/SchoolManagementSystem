using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagementSystem.Models;
using System.IO;
using System.Data.Entity.Validation;
using System.Data.Entity;
using DatabaseAccess;
using AutoMapper.QueryableExtensions;
using SchoolManagementSystem.ViewModels;
using SchoolManagementSystem.Repository;


namespace SchoolManagementSystem.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        //Db Context
        private readonly DbSchoolManagementSystemEntities _dbContext = new DbSchoolManagementSystemEntities();

        public bool AddCertificate(TblEmployeeCertificate Certificate, int EmployeeResumeId)
        {
            try
            {
                int countRecords = 0;
                TblEmployeeResume personEntity = _dbContext.TblEmployeeResumes.Where(Emp => Emp.EmployeeId == EmployeeResumeId).FirstOrDefault();

                if (personEntity != null && Certificate != null)
                {
                    personEntity.TblEmployeeCertificates.Add(Certificate);
                    countRecords = _dbContext.SaveChanges();
                }

                return countRecords > 0 ? true : false;
            }
            catch (DbEntityValidationException dbEx)
            {

                throw;
            }

        }

        public bool AddLanguage(TblEmployeeLanguage language, int EmployeeResumeId)
        {
            int countRecords = 0;
            TblEmployeeResume personEntity = _dbContext.TblEmployeeResumes.Where(Emp => Emp.EmployeeId == EmployeeResumeId).FirstOrDefault();

            if (personEntity != null && language != null)
            {
                personEntity.TblEmployeeLanguages.Add(language);
                countRecords = _dbContext.SaveChanges();
            }

            return countRecords > 0 ? true : false;
        }

        public string AddOrUpdateEducation(TblEmployeeEducation education, int EmployeeResumeId)
        {
            string msg = string.Empty;

            TblEmployeeResume personEntity = _dbContext.TblEmployeeResumes.Where(Emp => Emp.EmployeeId == EmployeeResumeId).FirstOrDefault();

            if (personEntity != null)
            {
                if (education.EmployeeEducationId > 0)
                {
                    //we will update education entity
                    _dbContext.Entry(education).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    msg = "Education entity has been updated successfully";
                }
                else
                {
                    // we will add new education entity
                    personEntity.TblEmployeeEducations.Add(education);
                    _dbContext.SaveChanges();

                    msg = "Education entity has been Added successfully";
                }
            }

            return msg;
        }

        public string AddOrUpdateExperience(TblEmployeeWorkExperience workExperience, int EmployeeResumeId)
        {
            string msg = string.Empty;

            TblEmployeeResume personEntity = _dbContext.TblEmployeeResumes.Where(Emp => Emp.EmployeeId == EmployeeResumeId).FirstOrDefault();

            if (personEntity != null)
            {
                if (workExperience.EmployeeWorkExperienceId > 0)
                {
                    //we will update work experience entity
                    _dbContext.Entry(workExperience).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    msg = "Work Experience entity has been updated successfully";
                }
                else
                {
                    // we will add new work experience entity
                    personEntity.TblEmployeeWorkExperiences.Add(workExperience);
                    _dbContext.SaveChanges();

                    msg = "Work Experience entity has been Added successfully";
                }
            }

            return msg;
        }

        public bool AddPersonnalInformation(TblEmployeeResume person, HttpPostedFileBase file)
        {
            try
            {
                int nbRecords = 0;

                if (person != null)
                {
                    if (file != null)
                    {
                       // person.EmployeeResumeImage = ConvertToBytes(file);
                    }

                    _dbContext.TblEmployeeResumes.Add(person);
                    nbRecords = _dbContext.SaveChanges();
                }

                return nbRecords > 0 ? true : false;
            }
            catch (DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        public bool AddSkill(TblEmployeeSkill skill, int EmployeeResumeId)
        {
            int countRecords = 0;
            TblEmployeeResume personEntity = _dbContext.TblEmployeeResumes.Where(Emp => Emp.EmployeeId == EmployeeResumeId).FirstOrDefault();

            if (personEntity != null && skill != null)
            {
                personEntity.TblEmployeeSkills.Add(skill);
                countRecords = _dbContext.SaveChanges();
            }

            return countRecords > 0 ? true : false;

        }

        public IQueryable<TblEmployeeCertificate> GetCertificateById(int EmployeeResumeId)
        {
            var certificateList = _dbContext.TblEmployeeCertificates.Where(w => w.EmployeeResumeId == EmployeeResumeId);
            return certificateList;
        }

        public IQueryable<TblEmployeeEducation> GetEducationById(int EmployeeResumeId)
        {
            var educationList = _dbContext.TblEmployeeEducations.Where(e => e.EmployeeResumeId == EmployeeResumeId);
            return educationList;
        }

        public int GetIdPerson(int EmployeeId)
        {
            int EmployeeResumeId = _dbContext.TblEmployeeResumes.Where(p => p.EmployeeId  == EmployeeId)
                                              .Select(p => p.EmployeeResumeId).FirstOrDefault();

            return EmployeeResumeId;
        }

        public IQueryable<TblEmployeeLanguage> GetLanguageById(int EmployeeResumeId)
        {
            var languageList = _dbContext.TblEmployeeLanguages.Where(w => w.EmployeeResumeId == EmployeeResumeId);
            return languageList;
        }

        public TblEmployeeResume GetPersonnalInfo(int EmployeeResumeId)
        {
            return _dbContext.TblEmployeeResumes.Find(EmployeeResumeId);
        }

        public IQueryable<TblEmployeeSkill> GetSkillById(int EmployeeResumeId)
        {
            var skillsList = _dbContext.TblEmployeeSkills.Where(w => w.EmployeeResumeId == EmployeeResumeId);
            return skillsList;
        }

        public IQueryable<TblEmployeeWorkExperience> GetWorkExperienceById(int EmployeeResumeId)
        {
            var workExperienceList = _dbContext.TblEmployeeWorkExperiences.Where(w => w.EmployeeResumeId == EmployeeResumeId);
            return workExperienceList;
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

    }

}
 