
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public   class StudentYearPatchLogic
    {
        private ApplicationDbContext db;

        public StudentYearPatchLogic()
        {
            db = new ApplicationDbContext();
        }

        public bool Delete(long PatchID, long YearId, long StudentsId)
        {
            try
            {
                StudentYearPatch studentYearPatch = db.StudentYearPatchs.FirstOrDefault(x => x.PatchID == PatchID&&x.StudentSeatingNumber == StudentsId&&x.YearID== YearId);
                db.StudentYearPatchs.Remove(studentYearPatch);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<StudentYearPatchDto> GetAll()
        {
            try
            {
                List<StudentYearPatch> studentYearPatches =db.StudentYearPatchs.ToList();
                List<StudentYearPatchDto> studentYearPatchDtos = new List<StudentYearPatchDto>();
                foreach (var studentYearPatche in studentYearPatches)
                {
                    StudentYearPatchDto studentYearPatchDto = new StudentYearPatchDto
                    {

                        PatchID = studentYearPatche.PatchID,
                        StateForpatch = studentYearPatche.StateForpatch,
                        StudentSeatingNumber = studentYearPatche.StudentSeatingNumber,
                        YearID = studentYearPatche.YearID


                    };
                    studentYearPatchDtos.Add(studentYearPatchDto);
                }
                return studentYearPatchDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public StudentYearPatchDto GetById(long PatchID, long YearId, long StudentsId)
        {
            try
            {
                StudentYearPatch studentYearPatch = db.StudentYearPatchs.FirstOrDefault(x => x.PatchID == PatchID && x.StudentSeatingNumber == StudentsId && x.YearID == YearId);

                StudentYearPatchDto studentYearPatchDto = new StudentYearPatchDto
                {

                    PatchID = studentYearPatch.PatchID,
                    StateForpatch = studentYearPatch.StateForpatch,
                    StudentSeatingNumber = studentYearPatch.StudentSeatingNumber,
                    YearID = studentYearPatch.YearID


                };
                return studentYearPatchDto;



            }
            catch (Exception ex )
            {

                throw ex;
            }

        }
   
        public bool Insert(StudentYearPatchDto StudentYearPatchDto)
        {
            try
            {
                StudentYearPatch studentYearPatch = new StudentYearPatch
                {

                    PatchID = StudentYearPatchDto.PatchID,
                    StateForpatch = StudentYearPatchDto.StateForpatch,
                    StudentSeatingNumber = StudentYearPatchDto.StudentSeatingNumber,
                    YearID = StudentYearPatchDto.YearID


                };
                db.StudentYearPatchs.Add(studentYearPatch);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public bool Update(StudentYearPatchDto StudentYearPatchDto, long PatchID, long YearId, long StudentsId)
        {
            try
            {
                StudentYearPatch studentYearPatch = new StudentYearPatch
                {

                    PatchID = StudentYearPatchDto.PatchID,
                    StateForpatch = StudentYearPatchDto.StateForpatch,
                    StudentSeatingNumber = StudentYearPatchDto.StudentSeatingNumber,
                    YearID = StudentYearPatchDto.YearID


                };
                StudentYearPatch studentYearPatchUpdated = db.StudentYearPatchs.FirstOrDefault(x => x.PatchID == PatchID && x.StudentSeatingNumber == StudentsId && x.YearID == YearId);
                studentYearPatchUpdated = studentYearPatch;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }        }
    }
}
