


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
   public class ControlLogic 
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ControlLogic()
        {
       
        }

        public bool Delete(long id)
        {
            
              
                try
                {
                    Control control = db.Control.FirstOrDefault(x => x.ID == id);
                    
                    if (control != null)
                        db.Control.Remove(control);

                    if (db.SaveChanges() > 0)

                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
        }

        public List<ControlDto> GetAll()
        {
            try
            {
                List<Control> Controls = db.Control.Select(x=>x).ToList();
                List<ControlDto> ControlDtos = new List<ControlDto>();
                foreach (var Control in Controls)
                {
                    ControlDto ControlDto = new ControlDto
                    {
                        ControlName = Control.ControlName ,
                        CreationDate = Control.CreationDate ,
                        ID = Control.ID ,
                        userID = Control.userID

                    };


                    ControlDtos.Add(ControlDto);



                }
                return ControlDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ControlDto GetById(long id)
        {
            try
            {
                Control control = db.Control.FirstOrDefault(x=> x.ID ==  id);

                ControlDto ControlDto = new ControlDto
                {
                    ControlName = control.ControlName,
                    CreationDate = control.CreationDate,
                    ID = control.ID,
                    userID = control.userID

                };
                return ControlDto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(ControlDto ControlDto)
        {
            try
            {
                Control control = new Control
                {
                    ControlName = ControlDto.ControlName,
                    CreationDate = ControlDto.CreationDate,
                    ID = ControlDto.ID,
                    userID = ControlDto.userID

                };
                db.Control.Add(control);
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

        public bool Update(ControlDto ControlDto, long id)
        {

            try
            {

                Control control = new Control
                {
                    ControlName = ControlDto.ControlName,
                    CreationDate = ControlDto.CreationDate,
                    ID = ControlDto.ID,
                    userID = ControlDto.userID

                };
                var entityUpdate = db.Control.FirstOrDefault(x=>x.ID == id);
                entityUpdate = control;
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
