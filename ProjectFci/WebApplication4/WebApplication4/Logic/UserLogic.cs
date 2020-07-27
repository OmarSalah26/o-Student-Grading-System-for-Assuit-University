
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class UserLogic
    {
        private ApplicationDbContext db;

        public UserLogic()
        {
            db = new ApplicationDbContext();
        }

        public bool Delete(string id)
        {
            try
            {
                User user = db.User.FirstOrDefault(x => x.ID == id);
                db.User.Remove(user);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserDto> GetAll()
        {
            try
            {
                List<User> users = db.User.ToList();
                List<UserDto> userDtos = new List<UserDto>();

                foreach (var user in users)
                {

                    UserDto userDto = new UserDto
                    {

                        CreationDate = user.CreationDate,
                        ID = user.ID,
                        Password = user.Password,

                        UserName = user.UserName,


                    };

                    userDtos.Add(userDto);
                }
                return userDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserDto GetById(string id)
        {
            try
            {
                User user = db.User.FirstOrDefault(x => x.ID == id);
                UserDto userDto = new UserDto
                {

                    CreationDate = user.CreationDate,
                    ID = user.ID,
                    Password = user.Password,
                    UserName = user.UserName,
                };
                return userDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public bool Insert(UserDto UserDto)
        //{
        //    try
        //    {
        //        User user = new User
        //        {

        //            CreationDate = UserDto.CreationDate,
        //            ID = UserDto.ID,
        //            Password = UserDto.Password,
        //            UserName = UserDto.UserName,
        //        };

        //        db.User.Add(user);
        //        if (db.SaveChanges() > 0)
        //            return true;
        //        return false;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public bool Update(UserDto UserDto)
        {
            try
            {
                User user = new User
                {

                    CreationDate = UserDto.CreationDate,
                    ID = UserDto.ID,
                    Password = UserDto.Password,
                    UserName = UserDto.UserName,
                };
                User userUpdate = db.User.FirstOrDefault(x => x.ID == UserDto.ID);
                userUpdate = user;

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
