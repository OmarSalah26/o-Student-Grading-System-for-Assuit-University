
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class PatchLogic { 
        private ApplicationDbContext db;

        public PatchLogic()
        {
            db = new ApplicationDbContext();
        }
        public bool Delete(long id)
        {
            try
            {
                Patch Patch = db.Patchs.FirstOrDefault(x => x.ID == id);
                db.Patchs.Remove(Patch);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<PatchDto> GetAll()
        {
            try
            {

                List<Patch> patches = db.Patchs.ToList();
                List<PatchDto> patchDtos = new List<PatchDto>();
                foreach (var patche in patches)
                {
                    PatchDto patchDto = new PatchDto
                    {
                        ID = patche.ID,
                        PatchName = patche.PatchName,
                        PatchNumber = patche.PatchNumber,

                    };
                    patchDtos.Add(patchDto);
                }
                return patchDtos;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PatchDto GetById(long id)
        {
            try
            {
                Patch patch = db.Patchs.FirstOrDefault(x => x.ID == id);
                PatchDto patchDto = new PatchDto
                {

                    ID = patch.ID,
                    PatchName = patch.PatchName,
                    PatchNumber = patch.PatchNumber,


                };
                return patchDto;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(PatchDto PatchDto)
        {
            try
            {
                Patch patch = new Patch
                {
                    ID = PatchDto.ID,
                    PatchName = PatchDto.PatchName,
                    PatchNumber = PatchDto.PatchNumber,


                };
                db.Patchs.Add(patch);
                if (db.SaveChanges() > 0)
                    return true;
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool Update(PatchDto PatchDto, long id)
        {
            try
            {
                Patch patch = new Patch
                {
                    ID = PatchDto.ID,
                    PatchName = PatchDto.PatchName,
                    PatchNumber = PatchDto.PatchNumber,


                };
                Patch PatchUpdated = db.Patchs.FirstOrDefault(x => x.ID == id);
                PatchUpdated = patch;
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
