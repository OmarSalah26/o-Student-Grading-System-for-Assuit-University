
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class SubjectEvaluationLogic 
    {
        private ApplicationDbContext db;

        public SubjectEvaluationLogic()
        {
            db = new ApplicationDbContext();
        }


        public bool Delete(long EvaluationId, string SubjectId)
        {
            try
            {
                SubjectEvaluation subjectEvaluation = db.SubjectEvaluations.FirstOrDefault(x => x.EvaluationId ==
                EvaluationId&&x.subjectcode == SubjectId);
                db.SubjectEvaluations.Remove(subjectEvaluation);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SubjectEvaluationDto> GetAll()
        {
            try
            {
                List<SubjectEvaluationDto> SubjectEvaluationDtos = new List<SubjectEvaluationDto>();

                List<SubjectEvaluation> SubjectEvaluations = db.SubjectEvaluations.ToList();

                foreach (var SubjectEvaluation in SubjectEvaluationDtos)
                {
                    SubjectEvaluationDto SubjectEvaluationDto = new SubjectEvaluationDto
                    {
                        EvaluationId = SubjectEvaluation.EvaluationId ,
                        subjectcode = SubjectEvaluation.subjectcode
                    };
                    SubjectEvaluationDtos.Add(SubjectEvaluationDto);



                }

                return SubjectEvaluationDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public SubjectEvaluationDto GetById(long EvaluationId, string SubjectId)
        {
            try
            {
                SubjectEvaluation subjectEvaluation = db.SubjectEvaluations.FirstOrDefault(x => x.EvaluationId == EvaluationId && x.subjectcode == SubjectId);

                SubjectEvaluationDto SubjectEvaluationDto = new SubjectEvaluationDto
                {
                    EvaluationId = subjectEvaluation.EvaluationId,
                    subjectcode = subjectEvaluation.subjectcode
                };

                return SubjectEvaluationDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool Insert(SubjectEvaluationDto SubjectEvaluationDto)
        {
            try
            {

                SubjectEvaluation subjectEvaluation = new SubjectEvaluation
                {
                    EvaluationId = SubjectEvaluationDto.EvaluationId,
                    subjectcode = SubjectEvaluationDto.subjectcode
                };
                db.SubjectEvaluations.Add(subjectEvaluation);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }

            
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public bool Update(SubjectEvaluationDto SubjectEvaluationDto, long EvaluationId, string SubjectId)
        {
            try
            {

                SubjectEvaluation SubjectEvaluation = new SubjectEvaluation
                {
                    EvaluationId = SubjectEvaluationDto.EvaluationId,
                    subjectcode = SubjectEvaluationDto.subjectcode
                };
                SubjectEvaluation subjectEvaluationUpdated      =db.SubjectEvaluations.FirstOrDefault(x => x.EvaluationId ==
                EvaluationId && x.subjectcode == SubjectId);

                subjectEvaluationUpdated = SubjectEvaluation;
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
