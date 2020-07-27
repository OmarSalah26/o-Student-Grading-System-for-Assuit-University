

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;
namespace WebApplication4.Logic
{
    public class ClemencyDegreeLogic
    {

        private ApplicationDbContext db;

        public ClemencyDegreeLogic()
        {
            db = new ApplicationDbContext();
        }




        public bool Delete(long id)
        {
            try
            {
                ClemencyDegree clemencyDegree = db.ClemencyDegree.FirstOrDefault(x => x.ID == id);
                db.ClemencyDegree.Remove(clemencyDegree);
                if (db.SaveChanges() > 0)
                    return true;
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ClemencyDegreeDto> GetAll()
        {

            try
            {
                List<ClemencyDegree> clemencyDegrees =db.ClemencyDegree.ToList();
                List<ClemencyDegreeDto> clemencyDegreeDtos = new List<ClemencyDegreeDto>();

                foreach (var _clemencyDegree in clemencyDegrees)
                {

                    ClemencyDegreeDto clemencyDegreeDto = new ClemencyDegreeDto
                    {
                        Describtion = _clemencyDegree.Describtion,
                        ID = _clemencyDegree.ID,
                        Max = _clemencyDegree.Max,
                        Min = _clemencyDegree.Min,


                    };
                    clemencyDegreeDtos.Add(clemencyDegreeDto);



                }
                return clemencyDegreeDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public ClemencyDegreeDto GetById(long id)
        {
            try
            {
                ClemencyDegree clemencyDegree = db.ClemencyDegree.FirstOrDefault(x => x.ID == id);

                ClemencyDegreeDto clemencyDegreeDto = new ClemencyDegreeDto
                {
                    Describtion = clemencyDegree.Describtion,
                    ID = clemencyDegree.ID,
                    Max = clemencyDegree.Max,
                    Min = clemencyDegree.Min,


                };
                return clemencyDegreeDto;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(ClemencyDegreeDto ClemencyDegreeDto)
        {
            try
            {
                ClemencyDegree clemencyDegree = new ClemencyDegree
                {


                    Describtion = ClemencyDegreeDto.Describtion,
                    ID = ClemencyDegreeDto.ID,
                    Max = ClemencyDegreeDto.Max,
                    Min = ClemencyDegreeDto.Min,

                };

                db.ClemencyDegree.Add(clemencyDegree);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(ClemencyDegreeDto ClemencyDegreeDto, long id)
        {
            try
            {
                ClemencyDegree clemencyDegree = new ClemencyDegree
                {


                    Describtion = ClemencyDegreeDto.Describtion,
                    ID = ClemencyDegreeDto.ID,
                    Max = ClemencyDegreeDto.Max,
                    Min = ClemencyDegreeDto.Min,

                };
                ClemencyDegree clemencyDegreeUpdated = db.ClemencyDegree.FirstOrDefault(x => x.ID == id);
                clemencyDegreeUpdated = clemencyDegree;
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
