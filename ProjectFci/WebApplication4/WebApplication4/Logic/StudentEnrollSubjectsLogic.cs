
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class StudentEnrollSubjectsLogic 
    {
        private ApplicationDbContext db;

        public StudentEnrollSubjectsLogic()
        {
            db = new ApplicationDbContext();
        }
        public bool Delete(string subjectcode, long StudentSeatingNumber)
        {
            try
            {
                StudentEnrollSubject studentEnrollSubject = db.StudentEnrollSubjects.FirstOrDefault(x => x.StudentSeatingNumber == StudentSeatingNumber&&x.subjectcode== subjectcode);
                db.StudentEnrollSubjects.Remove(studentEnrollSubject);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<StudentEnrollSubjectDto> GetAll()
        {
            try
            {
                List<StudentEnrollSubject> studentEnrollSubjects = db.StudentEnrollSubjects.ToList();
                List<StudentEnrollSubjectDto> studentEnrollSubjectDtos = new List<StudentEnrollSubjectDto>();
                foreach (var studentEnrollSubject in studentEnrollSubjects)
                {
                    StudentEnrollSubjectDto studentEnrollSubjectDto = new StudentEnrollSubjectDto
                    {
                        StudentSeatingNumber = studentEnrollSubject.StudentSeatingNumber,
                        ClemencyDegreeID = studentEnrollSubject.ClemencyDegreeID,
                        DateTimeCLD = studentEnrollSubject.DateTimeCLD,
                        DateTimeENL = studentEnrollSubject.DateTimeENL,
                        RateingForGrade = studentEnrollSubject.RateingForGrade,
               
                        StateStudentEnrollSubject = studentEnrollSubject.StateStudentEnrollSubject,
                        subjectcode = studentEnrollSubject.subjectcode,
                        TotalGrade = studentEnrollSubject.TotalGrade,
                        YearID = studentEnrollSubject.YearID

                    };


                    studentEnrollSubjectDtos.Add(studentEnrollSubjectDto);



                }
                return studentEnrollSubjectDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public StudentEnrollSubjectDto GetById(string subjectcode, long StudentSeatingNumber)
        {
            try
            {

                StudentEnrollSubject studentEnrollSubject = db.StudentEnrollSubjects.FirstOrDefault(x => x.StudentSeatingNumber == StudentSeatingNumber && x.subjectcode == subjectcode);


                StudentEnrollSubjectDto studentEnrollSubjectDto = new StudentEnrollSubjectDto
                {
                    StudentSeatingNumber = studentEnrollSubject.StudentSeatingNumber,
                    ClemencyDegreeID = studentEnrollSubject.ClemencyDegreeID,
                    DateTimeCLD = studentEnrollSubject.DateTimeCLD,
                    DateTimeENL = studentEnrollSubject.DateTimeENL,
                    RateingForGrade = studentEnrollSubject.RateingForGrade,
          
                    StateStudentEnrollSubject = studentEnrollSubject.StateStudentEnrollSubject,
                    subjectcode = studentEnrollSubject.subjectcode,
                    TotalGrade = studentEnrollSubject.TotalGrade,
                    YearID = studentEnrollSubject.YearID

                };
                return studentEnrollSubjectDto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public bool Insert(StudentEnrollSubjectDto studentEnrollSubjectDto , List<string> subjectcodes)
        {
            try
            {



                foreach (var item in subjectcodes)
                {
                    StudentEnrollSubject studentEnrollSubject = new StudentEnrollSubject
                    {
                        StudentSeatingNumber = studentEnrollSubjectDto.StudentSeatingNumber,
                        ClemencyDegreeID = 1, // هتتفتح لما الدكتور يبقا عاير يضيف رافه 
                        DateTimeCLD = DateTime.Now,
                        DateTimeENL = DateTime.Now,
                        //RateingForGrade = studentEnrollSubjectDto.RateingForGrade, // هتتحسب ضمنيا
                        StateStudentEnrollSubject = studentEnrollSubjectDto.StateStudentEnrollSubject,
                        subjectcode = item,
                        // TotalGrade = studentEnrollSubjectDto.TotalGrade, //هتتحسب ضمنيا
                        YearID = 1, ////removed
                    };

                    db.StudentEnrollSubjects.Add(studentEnrollSubject);

                }


                if (db.SaveChanges() > 0)
                    return true;
                return false;



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public bool Update(StudentEnrollSubjectDto studentEnrollSubjectDto)
        {
            try
            {


                StudentEnrollSubject studentEnrollSubject = new StudentEnrollSubject
                {
                    StudentSeatingNumber = studentEnrollSubjectDto.StudentSeatingNumber,
                    ClemencyDegreeID = studentEnrollSubjectDto.ClemencyDegreeID,
                    DateTimeCLD = studentEnrollSubjectDto.DateTimeCLD,
                    DateTimeENL = studentEnrollSubjectDto.DateTimeENL,
                    RateingForGrade = studentEnrollSubjectDto.RateingForGrade,
                    StateStudentEnrollSubject = studentEnrollSubjectDto.StateStudentEnrollSubject,
                    subjectcode = studentEnrollSubjectDto.subjectcode,
                    TotalGrade = studentEnrollSubjectDto.TotalGrade,
                    YearID = studentEnrollSubjectDto.YearID


                };
                StudentEnrollSubject studentEnrollSubjectUpdate = db.StudentEnrollSubjects.FirstOrDefault(x => x.StudentSeatingNumber == studentEnrollSubjectDto.StudentSeatingNumber && x.subjectcode == studentEnrollSubjectDto.subjectcode);

                studentEnrollSubjectUpdate = studentEnrollSubject;
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





