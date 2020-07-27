
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class EvaluationSubjectStudentLogic 
    {
        private ApplicationDbContext db;

        public EvaluationSubjectStudentLogic()
        {
            db = new ApplicationDbContext();
        }
        public bool Delete(long EvaluationId, string SubjectId  ,long StudentsId)
        {
            try
            {
                EvaluationSubjectStudent EvaluationSubjectStudent = db.EvaluationSubjectStudents.FirstOrDefault(x => x.EvaluationID == EvaluationId&&
                x.subjectcode== SubjectId&&x.StudentSeatingNumber == StudentsId);
                db.EvaluationSubjectStudents.Remove(EvaluationSubjectStudent);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        public List<EvaluationSubjectStudentDto> GetAll()
        {
            try
            {
                List<EvaluationSubjectStudentDto> evaluationSubjectStudentDtos = new List<EvaluationSubjectStudentDto>();

                List<EvaluationSubjectStudent> EvaluationSubjectStudents = db.EvaluationSubjectStudents.ToList();

                foreach (var EvaluationSubjectStudent in EvaluationSubjectStudents)
                {
                    EvaluationSubjectStudentDto evaluationSubjectStudentDto = new EvaluationSubjectStudentDto
                    {
                        Abs = EvaluationSubjectStudent.Abs,

                        EvaluationID = EvaluationSubjectStudent.EvaluationID,
                        Grade = EvaluationSubjectStudent.Grade,
                        Note = EvaluationSubjectStudent.Note,
                        StudentSeatingNumber = EvaluationSubjectStudent.StudentSeatingNumber,
                        subjectcode = EvaluationSubjectStudent.subjectcode,

                    };
                    evaluationSubjectStudentDtos.Add(evaluationSubjectStudentDto);



                }

                return evaluationSubjectStudentDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public EvaluationSubjectStudentDto GetById(long EvaluationId, string SubjectId, long StudentsId)
        {
            try
            {
                EvaluationSubjectStudent evaluationSubjectStudent = db.EvaluationSubjectStudents.FirstOrDefault(x => x.EvaluationID == EvaluationId &&
                              x.subjectcode == SubjectId && x.StudentSeatingNumber == StudentsId);
                //exception if return is null not can decleare Dto 
                //Edit by HF
                if (evaluationSubjectStudent==  null)
                {
                    return null;
                }
                EvaluationSubjectStudentDto evaluationSubjectStudentDto = new EvaluationSubjectStudentDto
                {
                    Abs = evaluationSubjectStudent.Abs,

                    EvaluationID = evaluationSubjectStudent.EvaluationID,
                    Grade = evaluationSubjectStudent.Grade,
                    Note = evaluationSubjectStudent.Note,
                    StudentSeatingNumber = evaluationSubjectStudent.StudentSeatingNumber,
                    subjectcode = evaluationSubjectStudent.subjectcode,

                };

                return evaluationSubjectStudentDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool Insert(EvaluationSubjectStudentDto EvaluationSubjectStudentDto)
        {
            try
            {

                EvaluationSubjectStudent evaluationSubjectStudent = new EvaluationSubjectStudent
                {
                    Abs = EvaluationSubjectStudentDto.Abs,

                    EvaluationID = EvaluationSubjectStudentDto.EvaluationID,
                    Grade = EvaluationSubjectStudentDto.Grade,
                    Note = EvaluationSubjectStudentDto.Note,
                    StudentSeatingNumber = EvaluationSubjectStudentDto.StudentSeatingNumber,
                    subjectcode = EvaluationSubjectStudentDto.subjectcode,

                };
                db.EvaluationSubjectStudents.Add(evaluationSubjectStudent);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public bool Update(EvaluationSubjectStudentDto EvaluationSubjectStudentDto, long EvaluationId, string SubjectId, long StudentsId)
        {
            try
            {

                EvaluationSubjectStudent evaluationSubjectStudent = new EvaluationSubjectStudent
                {
                    Abs = EvaluationSubjectStudentDto.Abs,

                    EvaluationID = EvaluationSubjectStudentDto.EvaluationID,
                    Grade = EvaluationSubjectStudentDto.Grade,
                    Note = EvaluationSubjectStudentDto.Note,
                    StudentSeatingNumber = EvaluationSubjectStudentDto.StudentSeatingNumber,
                    subjectcode = EvaluationSubjectStudentDto.subjectcode,

                };

                EvaluationSubjectStudent evaluationSubjectStudentUpdated = db.EvaluationSubjectStudents.FirstOrDefault(x => x.EvaluationID == EvaluationId &&
                           x.subjectcode == SubjectId && x.StudentSeatingNumber == StudentsId);
                evaluationSubjectStudentUpdated.Abs = evaluationSubjectStudent.Abs;
                
                evaluationSubjectStudentUpdated.EvaluationID = evaluationSubjectStudent.EvaluationID;
                evaluationSubjectStudentUpdated.Grade = evaluationSubjectStudent.Grade;
                evaluationSubjectStudentUpdated.Note = evaluationSubjectStudent.Note;
                evaluationSubjectStudentUpdated.StudentSeatingNumber = evaluationSubjectStudent.StudentSeatingNumber;
                evaluationSubjectStudentUpdated.subjectcode = evaluationSubjectStudent.subjectcode;

                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
