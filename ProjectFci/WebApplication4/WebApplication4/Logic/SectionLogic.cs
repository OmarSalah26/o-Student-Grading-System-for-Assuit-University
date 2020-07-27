

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class SectionLogic
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public SectionLogic()
        {

        }
        public bool Delete(long id)
        {
            try
            {
                section section = db.sections.FirstOrDefault(x => x.id == id);

                if (section != null)
                    db.sections.Remove(section);

                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SectionDto> GetAll()
        {
            try
            {


                List<section> sections = db.sections.ToList();
                List<SectionDto> sectionsDtos = new List<SectionDto>();
                foreach (var Section in sections)
                {
                    SectionDto sectionDto = new SectionDto
                    {
                        id = Section.id,
                        description = Section.description,
                        name = Section.name
                    };


                    sectionsDtos.Add(sectionDto);



                }
                return sectionsDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public SectionDto GetById(long id)
        {
            try
            {
                section Section = db.sections.FirstOrDefault(x => x.id == id);
                if (Section != null)
                {
                    SectionDto sectionDto = new SectionDto
                    {
                        id = Section.id,
                        description = Section.description,
                        name = Section.name
                    };
                    return sectionDto;
                }
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(SectionDto SectionDto)
        {
            try
            {
                section Section = new section
                {
                    name = SectionDto.name,
                    description = SectionDto.description,
                    id = SectionDto.id

                };

                db.sections.Add(Section);
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

        public bool Update(SectionDto SectionDto, long id)
        {
            try
            {

                section Section = new section
                {
                    name = SectionDto.name,
                    description = SectionDto.description,
                    id = SectionDto.id

                };
                section rateUpdate = db.sections.FirstOrDefault(x => x.id == id);
                rateUpdate = Section;
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
