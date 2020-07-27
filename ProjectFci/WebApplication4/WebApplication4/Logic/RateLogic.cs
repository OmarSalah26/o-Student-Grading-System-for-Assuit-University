
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class RateLogic
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public RateLogic()
        {
        
        }
        public bool Delete(long id)
        {
            try
            {
                Rate rate = db.Rates.FirstOrDefault(x => x.id == id);

                if (rate != null)
                    db.Rates.Remove(rate);

                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RateDto> GetAll()
        {
            try
            {
                List<Rate> rates = db.Rates.ToList();
                List<RateDto> rateDtos = new List<RateDto>();
                foreach (var rate in rates)
                {
                    RateDto rateDto = new RateDto
                    {
                        Min = rate.Min,
                        Max = rate.Max,
                        description = rate.description,
                        id = rate.id
                    };


                    rateDtos.Add(rateDto);



                }
                return rateDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RateDto GetById(long id)
        {
            try
            {
                Rate rate = db.Rates.FirstOrDefault(x => x.id == id);
                if (rate != null)
                { 
                    RateDto rateDto = new RateDto
                    {
                        Min = rate.Min,
                        Max = rate.Max,
                        description = rate.description,
                        id = rate.id
                    };
                    return rateDto;
                }
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(RateDto RateDto)
        {
            try
            {
                Rate rate = new Rate
                {
                    id = RateDto.id,
                    description = RateDto.description,
                    Max = RateDto.Max,
                    Min = RateDto.Min,


                };

                db.Rates.Add(rate);
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

        public bool Update(RateDto RateDto, long id)
        {

            try
            {

                Rate rate = new Rate
                {
                    id = RateDto.id ,
                    description = RateDto.description ,
                    Max = RateDto.Max ,
                    Min = RateDto.Min , 
                    

                };
                Rate rateUpdate = db.Rates.FirstOrDefault(x => x.id == id);
                rateUpdate = rate;
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
