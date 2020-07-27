

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class SubjectLogic 
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public bool Delete(string SubjectCode)
        {
            try
            {
                Subject subject = db.Subjects.FirstOrDefault(x=>x.SubjectCode == SubjectCode);

                if (subject != null)
                    db.Subjects.Remove(subject);

                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SubjectDto> GetAll()
        {
            try
            {
                List<Subject> Subjects = db.Subjects.ToList();
                List<SubjectDto> subjectDtos = new List<SubjectDto>();
                foreach (var subject in Subjects)
                {
                    SubjectDto subjectDto = new SubjectDto
                    {

                        Description = subject.Description,
                        PatchId = subject.PatchId,
                        Semester = subject.Semester,
                        SubjectCode = subject.SubjectCode,
                        SubjectName = subject.SubjectName
                    };
                    subjectDtos.Add(subjectDto);
                }
                return subjectDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SubjectDto GetById(string SubjectCode)
        {
            try
            {
                Subject subject = db.Subjects.FirstOrDefault(x => x.SubjectCode == SubjectCode);
                SubjectDto subjectDto = new SubjectDto()
                {

                    Description = subject.Description,
                    PatchId = subject.PatchId,
                    Semester = subject.Semester,
                    SubjectCode = subject.SubjectCode,
                    SubjectName = subject.SubjectName

                };
                return subjectDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Insert(SubjectDto subjectDto, List<long> Evaluations, List<long> Rates)
        {
            try
            {
                SubjectEvaluationLogic _subjectEvaluationLogic = new SubjectEvaluationLogic();
                SubjectRateLogic subjectRateLogic = new SubjectRateLogic();


                Subject subject = new Subject()
                {


                    SubjectName = subjectDto.SubjectName,
                    SubjectCode = subjectDto.SubjectCode,
                    PatchId = subjectDto.PatchId,
                    Description = subjectDto.Description,
                    Semester = subjectDto.Semester
                };
                db.Subjects.Add(subject);
                if (db.SaveChanges() > 0)
                {


                    foreach (var item in Evaluations)
                    {
                        SubjectEvaluationDto subjectEvaluationDto = new SubjectEvaluationDto
                        {
                            EvaluationId = item,
                            subjectcode = subject.SubjectCode
                        };
                        _subjectEvaluationLogic.Insert(subjectEvaluationDto);
                    }
                    foreach (var item in Rates)
                    {
                        SubjectRateDto subjectRateDto = new SubjectRateDto
                        {
                            RateId = item,
                            subjectcode = subject.SubjectCode
                        };
                        subjectRateLogic.Insert(subjectRateDto);
                    }
                    return true;
                }



                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(SubjectDto subjectDto)
        {
            try
            {
                Subject subject = new Subject()
                {
                    PatchId = subjectDto.PatchId,
                    SubjectName = subjectDto.SubjectName,
                    Semester = subjectDto.Semester,
                    Description = subjectDto.Description,
                    SubjectCode = subjectDto.SubjectCode

                };
                Subject subjectupdate = db.Subjects.FirstOrDefault(x => x.SubjectCode == subjectDto.SubjectCode);
                subjectupdate = subject;
                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
