
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    class SubjectRateLogic 
    {
        private ApplicationDbContext db;

        public SubjectRateLogic()
        {
            db = new ApplicationDbContext();
        }

        public bool Delete(long RateId, string SubjectId)
        {
            try
            {
                SubjectRate sbjectRate = db.SubjectRates.FirstOrDefault(x => x.RateId == RateId&& x.subjectcode == SubjectId);
                db.SubjectRates.Remove(sbjectRate);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<SubjectRateDto> GetAll()
        {
            try
            {

                List<SubjectRate> subjectRates =db.SubjectRates.ToList();
                List<SubjectRateDto> subjectRateDtos = new List<SubjectRateDto>();
                foreach (var subjectRate in subjectRates)
                {
                    SubjectRateDto subjectRateDto = new SubjectRateDto
                    {
                        RateId = subjectRate.RateId,
                        subjectcode = subjectRate.subjectcode,
                    };


                    subjectRateDtos.Add(subjectRateDto);



                }
                return subjectRateDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public SubjectRateDto GetById(long RateId, string SubjectId)
        {
            try
            {

                SubjectRate sbjectRate = db.SubjectRates.FirstOrDefault(x => x.RateId == RateId && x.subjectcode == SubjectId);

                SubjectRateDto subjectRateDto = new SubjectRateDto
                {
                    RateId = sbjectRate.RateId,
                    subjectcode = sbjectRate.subjectcode,
                };
                return subjectRateDto;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool Insert(SubjectRateDto subjectRateDto)
        {
            try
            {


                SubjectRate subjectRate = new SubjectRate
                {
                    subjectcode = subjectRateDto.subjectcode,
                    RateId = subjectRateDto.RateId,

                };

                db.SubjectRates.Add(subjectRate);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool Update(SubjectRateDto studentDto, long RateId, string SubjectId)
        {
            try
            {


                SubjectRate subjectRate = new SubjectRate
                {
                    subjectcode = studentDto.subjectcode,
                    RateId = studentDto.RateId,

                };
                SubjectRate sbjectRateUpdate=db.SubjectRates.FirstOrDefault(x => x.RateId == RateId && x.subjectcode == SubjectId);

                sbjectRateUpdate = subjectRate;

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
    

