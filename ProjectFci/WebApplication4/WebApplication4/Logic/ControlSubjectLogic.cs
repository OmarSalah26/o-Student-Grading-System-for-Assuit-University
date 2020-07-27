
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class ControlSubjectLogic 
    {

        private ApplicationDbContext db;

        public ControlSubjectLogic()
        {
            db = new ApplicationDbContext();
        }
        public bool Delete(long idOfControl, string idOfSubject)
        {
            try
            {
                ControlSubject controlSubject = db.ControlSubjects.FirstOrDefault(x => x.ControlId == idOfControl && x.subjectcode == idOfSubject);
                db.ControlSubjects.Remove(controlSubject);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      
        public List<ControlSubjectDto> GetAll()
        {
            try
            {
                List<ControlSubject> controlSubjects =db.ControlSubjects.ToList();
                List<ControlSubjectDto> controlSubjectDtos = new List<ControlSubjectDto>();
                foreach (var controlSubject in controlSubjects)
                {
                    ControlSubjectDto controlSubjectDto = new ControlSubjectDto
                    {
                        ControlId = controlSubject.ControlId,
                        subjectcode = controlSubject.subjectcode,


                    };
                    controlSubjectDtos.Add(controlSubjectDto);
                }
                return controlSubjectDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ControlSubjectDto GetById(long idOfControl, string idOfSubject)
        {
            try
            {
                ControlSubject controlSubject = db.ControlSubjects.FirstOrDefault(x => x.ControlId == idOfControl && x.subjectcode == idOfSubject);

                ControlSubjectDto controlSubjectDto = new ControlSubjectDto
                {
                    ControlId = controlSubject.ControlId,
                    subjectcode = controlSubject.subjectcode
                };
                return controlSubjectDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(ControlSubjectDto controlSubjectDto)
        {
            try
            {
                ControlSubject controlSubject = new ControlSubject
                {
                    subjectcode = controlSubjectDto.subjectcode,
                    ControlId = controlSubjectDto.ControlId,


                };

                db.ControlSubjects.Add(controlSubject);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception x)
            {

                throw x;
            }
        }

        public bool Update(ControlSubjectDto controlSubjectDto, long idOfControl, string idOfSubject)
        {
            ControlSubject controlSubject = new ControlSubject
            {
                ControlId = controlSubjectDto.ControlId,
                subjectcode = controlSubjectDto.subjectcode,
            };
            ControlSubject controlSubjectUpdated = db.ControlSubjects.FirstOrDefault(x => x.ControlId == idOfControl && x.subjectcode == idOfSubject);
            controlSubjectUpdated = controlSubject;

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }


    }
}
