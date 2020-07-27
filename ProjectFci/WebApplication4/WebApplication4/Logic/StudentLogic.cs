

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class StudentLogic 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public StudentLogic()
        {

        }


        public List<StudentDto> GetAll(String subjectCode)
        {

            var AllStudentAssignInSubject = (from x in db.StudentEnrollSubjects
                                             where x.subjectcode == subjectCode
                                             select x.Student
                                           ).ToList();

            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (var student in AllStudentAssignInSubject)
            {
                StudentDto studentDto = new StudentDto
                {
                    BirthPlace = student.BirthPlace,

                    Name = student.Name,
                    NationalIdNumber = student.NationalIdNumber,
                    Nationality = student.Nationality,
                    SeatingNumber = student.SeatingNumber,
                    SectionID = student.SectionID

                };


                studentDtos.Add(studentDto);



            }
            return studentDtos;


        }

        public bool Delete(long StudentSeatingNumber)
        {
            try
            {

                Student student = db.Students.FirstOrDefault(x => x.SeatingNumber == StudentSeatingNumber);

                if (student != null)
                    db.Students.Remove(student);

                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<StudentDto> GetAll()
        {
            try
            {
                List<Student> students = db.Students.ToList();
                List<StudentDto> studentDtos = new List<StudentDto>();
                foreach (var student in students)
                {
                    StudentDto studentDto = new StudentDto
                    {
                        BirthPlace = student.BirthPlace,
                    
                        Name = student.Name,
                        NationalIdNumber = student.NationalIdNumber,
                        Nationality = student.Nationality,
                        SeatingNumber = student.SeatingNumber,
                        SectionID = student.SectionID

                    };


                    studentDtos.Add(studentDto);



                }
                return studentDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public StudentDto GetById(long StudentSeatingNumber)
        {
            try
            {
                Student student = db.Students.FirstOrDefault(x => x.SeatingNumber == StudentSeatingNumber);

                StudentDto studentDto = new StudentDto
                {
                    BirthPlace = student.BirthPlace,
            
                    Name = student.Name,
                    NationalIdNumber = student.NationalIdNumber,
                    Nationality = student.Nationality,
                    SeatingNumber = student.SeatingNumber,
                    SectionID = student.SectionID


                };
                return studentDto;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(StudentDto studentDto)
        {
            try
            {
                Student student = new Student
                {
                   
                    BirthPlace = studentDto.BirthPlace,
                    SectionID = studentDto.SectionID,
                    Name = studentDto.Name,
                    NationalIdNumber = studentDto.NationalIdNumber,
                    SeatingNumber = studentDto.SeatingNumber,
                    Nationality = studentDto.Nationality,

                };

                 db.Students.Add(student);
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

        public bool Update(StudentDto studentDto, long StudentSeatingNumber)
        {

            try
            {

                Student student = new Student
                {

         
                    BirthPlace = studentDto.BirthPlace,
                    SectionID = studentDto.SectionID,
                    Name = studentDto.Name,
                    NationalIdNumber = studentDto.NationalIdNumber,
                    SeatingNumber = studentDto.SeatingNumber,
                    Nationality = studentDto.Nationality,

                };
                Student studentUpdate = db.Students.FirstOrDefault(x => x.SeatingNumber == StudentSeatingNumber);
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
