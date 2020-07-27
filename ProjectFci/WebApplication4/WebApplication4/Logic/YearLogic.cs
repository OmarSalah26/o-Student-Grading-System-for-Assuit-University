
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class YearLogic 
    {
        private ApplicationDbContext db ;

        public YearLogic()
        {
            db = new ApplicationDbContext();
        }
        

        public bool Delete(long id)
        {
            try
            {
                Year year = db.Years.FirstOrDefault(x=>x.id==id);
                db.Years.Remove(year);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<YearDto> GetAll()
        {
            try
            {
                List<Year> years =db.Years.ToList();

                List<YearDto> yearDtos = new List<YearDto>();

                foreach (var year in years)
                {
                    YearDto yearDto = new YearDto
                    {
                        id = year.id,
                        YearNumber = year.YearNumber,

                    };
                    yearDtos.Add(yearDto);
                }
                return yearDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public YearDto GetById(long id)
        {

            try
            {
                Year year = db.Years.FirstOrDefault(x => x.id == id);
                YearDto yearDto = new YearDto
                {
                    id = year.id,
                    YearNumber = year.YearNumber,

                };
                return yearDto;
            }
            catch (Exception  ex)
            {

                throw ex;
            }
        }

        public bool Insert(YearDto yearDto)
        {
            try
            {
                Year year = new Year
                {
                    id = yearDto.id,
                    YearNumber = yearDto.YearNumber,

                };

                db.Years.Add(year);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
      
  

        public bool Update(YearDto yearDto, long id)
        {
            try
            {
                Year year = new Year
                {
                    id = yearDto.id,
                    YearNumber = yearDto.YearNumber,

                };
                Year yearUpdate = db.Years.FirstOrDefault(x => x.id == id);

                yearUpdate = year;
                if (db.SaveChanges() > 0)
                    return true;
                return false; ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
