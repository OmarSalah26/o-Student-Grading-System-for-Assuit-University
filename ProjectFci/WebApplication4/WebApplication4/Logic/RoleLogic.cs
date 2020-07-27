
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{


    public class RoleLogic
    {
        private ApplicationDbContext db;

        public RoleLogic()
        {
            db = new ApplicationDbContext();
        }

        public bool Delete(string id)
        {
            try
            {
                IdentityRole Role = db.Roles.FirstOrDefault(x => x.Id == id);
                db.Roles.Remove(Role);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RoleDto> GetAll()
        {
            try
            {
                List<IdentityRole> roles = db.Roles.ToList();
                List<RoleDto> roleDtos = new List<RoleDto>();

                foreach (var role in roles)
                {
                    RoleDto roleDto = new RoleDto
                    {
                        ID = role.Id,
                        RoleName = role.Name,


                    };
                    roleDtos.Add(roleDto);
                }

                return roleDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public RoleDto GetById(string id)
        {
            try
            {
                IdentityRole role = db.Roles.FirstOrDefault(x => x.Id == id);
                RoleDto roleDto = new RoleDto
                {

                    ID = role.Id,
                    RoleName = role.Name,
                };

                return roleDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(RoleDto RoleDto)
        {

            try
            {

                IdentityRole role = new IdentityRole
                {

                    Id = RoleDto.ID,
                    Name = RoleDto.RoleName,
                };

                db.Roles.Add(role);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(RoleDto RoleDto)
        {
            try
            {

                IdentityRole role = new IdentityRole
                {

                    Id = RoleDto.ID,
                    Name = RoleDto.RoleName,
                };
                IdentityRole roleUpdated = db.Roles.FirstOrDefault(x => x.Id == RoleDto.ID);
                roleUpdated = role;
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
