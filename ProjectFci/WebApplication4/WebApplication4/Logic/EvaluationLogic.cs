
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class EvaluationLogic 
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public EvaluationLogic()
        {
        
        }

        public bool Delete(long id)
        {
            try
            {
                Evaluation Evaluation = db.Evaluations.FirstOrDefault(x => x.id == id);

                if (Evaluation != null)
                    db.Evaluations.Remove(Evaluation);

                if (db.SaveChanges() > 0)

                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EvaluationDto> GetAll()
        {
            try
            {
                List<Evaluation> evaluations = db.Evaluations.ToList();
                List<EvaluationDto> EvaluationDtos = new List<EvaluationDto>();
                foreach (var evaluation in evaluations)
                {
                    EvaluationDto evaluationDto = new EvaluationDto
                    {
                        id = evaluation.id ,
                        Description = evaluation.Description ,
                        Max = evaluation.Max ,
                        Min = evaluation.Min 

                    };


                    EvaluationDtos.Add(evaluationDto);



                }
                return EvaluationDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EvaluationDto GetById(long id)
        {
            try
            {
                Evaluation evaluation = db.Evaluations.FirstOrDefault(x=>x.id == id);

                EvaluationDto evaluationDto = new EvaluationDto
                {
                    id = evaluation.id,
                    Description = evaluation.Description,
                    Max = evaluation.Max,
                    Min = evaluation.Min

                };
                return evaluationDto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(EvaluationDto EvaluationDto)
        {
            try
            {
                Evaluation evaluation = new Evaluation
                {
                    Min = EvaluationDto.Min ,
                    Max = EvaluationDto.Max ,
                    Description = EvaluationDto.Description ,
                    id = EvaluationDto.id ,
                    

                };

                db.Evaluations.Add(evaluation);
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

        public bool Update(EvaluationDto EvaluationDto, long id)
        {

            try
            {

                Evaluation evaluation = new Evaluation
                {
                    Min = EvaluationDto.Min,
                    Max = EvaluationDto.Max,
                    Description = EvaluationDto.Description,
                    id = EvaluationDto.id,


                };
                Evaluation evaluationUpdate = db.Evaluations.FirstOrDefault(x => x.id == id);
                evaluationUpdate = evaluation;
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

