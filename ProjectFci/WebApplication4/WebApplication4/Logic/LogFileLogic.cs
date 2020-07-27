

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Logic
{
    public class LogFileLogic 
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public LogFileLogic()
        {
           
        }
        public List<LogFileDto> GetAll()
        {
            try
            {
                List<LogFile> logFiles = db.LogFiles.ToList();
                List<LogFileDto> logFileDtos = new List<LogFileDto>();
                foreach (var logFile in logFiles)
                {
                    LogFileDto LogFileDto = new LogFileDto
                    {
                       id = logFile.id ,
                       DataTime = logFile.DataTime ,
                       Query = logFile.Query ,
                       UserId = logFile.UserId

                    };


                    logFileDtos.Add(LogFileDto);



                }
                return logFileDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LogFileDto GetById(long id)
        {
            try
            {
                LogFile logFile = db.LogFiles.FirstOrDefault(x => x.id == id);

                LogFileDto LogFileDto = new LogFileDto
                {
                    id = logFile.id,
                    DataTime = logFile.DataTime,
                    Query = logFile.Query,
                    UserId = logFile.UserId

                };
                return LogFileDto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(LogFileDto logFileDto)
        {
            try
            {
                LogFile logfile = new LogFile
                {
                    UserId = logFileDto.UserId ,
                    Query = logFileDto.Query ,
                    DataTime =  logFileDto.DataTime ,
                    id = logFileDto.id

                };

                db.LogFiles.Add(logfile);
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
